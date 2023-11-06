using Duende.IdentityServer.Models;
using GestorStock.BD.Data;
using GestorStock.BD.Data.Entity;
using GestorStock.Shared.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorStock.Server.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private readonly Context context;

        public StockController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> Get()
        {
            //var lista = await context.Stocks.ToListAsync();

            var lista = await context.Stocks
                    .Include(Stock => Stock.Productos)
                    .ToListAsync();


            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay stock");
            }

            return lista;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Stock>> Get(int id)
        {
            var existe = await context.Stocks.AnyAsync(x => x.id == id);
            if (!existe) //productos//
            {
                return NotFound($"El estado {id} no existe");
            }
            return await context.Stocks.FirstOrDefaultAsync(ped => ped.id == id);
        }

        [HttpPost]

        
        public async Task<ActionResult<int>> Post(StockDTO entidad)
        {
            try
            {
                var existe = await context.Depositos.AnyAsync(x => x.id == entidad.DepositoId);
                if (!existe)
                {
                    return NotFound($"El Deposito de id = {entidad.DepositoId} no existe");
                }
                var existes = await context.Productos.AnyAsync(x => x.id == entidad.ProductoId);
                if (!existes)
                {
                    return NotFound($"El producto de id={entidad.ProductoId} no existe");
                }

                //Revisa que lo que se quiera cargar sea un producto compuesto
                var chequeo = await context.ProductoComponentes.AnyAsync(x => x.ProductoId == entidad.ProductoId);
                if (chequeo)
                {
                    //Para cada producto compuesto
                    foreach (var item in context.ProductoComponentes)
                    {
                        //Que se relaciona con prodId
                        if (item.ProductoId == entidad.ProductoId)
                        {
                            //Se guarda la cantidad de insumos necesarios 
                            var cant = item.cantidad*entidad.cantidad;
                            //Guardo el ID del componente
                            var comp = item.ComponenteId;                          

                            //Reviso la tabla de componentes
                            foreach (var componente in context.Componentes)
                            {
                                //Cuando encuentro el componente en cuestion
                                if (componente.id == comp)
                                {
                                    //Guardo su producto ID
                                    var prodId = componente.ProductoId;
                                    //Busco el producto en la tabla de stock
                                    var stock = await context.Stocks.AnyAsync(x => x.ProductoId == prodId && x.DepositoId == entidad.DepositoId);

                                    //En caso de que exista
                                    if (stock)
                                    {
                                        //busco para cada insumo la cantidad cargada
                                        foreach (var insumo in context.Stocks)
                                        {
                                            //Para el insumo necesario
                                            if (insumo.ProductoId == prodId)
                                            {

                                                //Guardo la cantidad actual
                                                var cantInsumo = insumo.cantidad;
                                                if (cantInsumo >= cant)
                                                {
                                                    //Actualizo la cantidad 
                                                    insumo.cantidad = insumo.cantidad - cant;
                                                    
                                                    context.Update(insumo);
                                                    await context.SaveChangesAsync();
                                                    
                                                }
                                                else
                                                {
                                                    errormessage = "Faltan componentes";
                                                    return BadRequest("Faltan componentes");  
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        errormessage = "Faltan componentes";
                                        return BadRequest("Faltan componentes");
                                    }
                                }
                            }
                        }
                    }
                }

                //Validacion para sumar cantidades en caso de cargar el mismo producto
                var existenteStock = await context.Stocks.FirstOrDefaultAsync(x => x.ProductoId == entidad.ProductoId && x.DepositoId == entidad.DepositoId);
                if (existenteStock != null)
                {
                    //Modifica la cantidad del producto
                    existenteStock.cantidad = existenteStock.cantidad+ entidad.cantidad;
                    context.Update(existenteStock);
                    await context.SaveChangesAsync();
                }
                else
                {
                    //Crea un nuevo Stock

                    Stock nuevostock = new Stock();

                    nuevostock.DepositoId = entidad.DepositoId;
                    nuevostock.cantidad = entidad.cantidad;
                    nuevostock.estado = entidad.estado;
                    nuevostock.ProductoId = entidad.ProductoId;

                    await context.AddAsync(nuevostock);
                    await context.SaveChangesAsync();
                }

                //Validacion para que desaparezcan las filas cuya cantidad sea 0
                foreach (var stock in context.Stocks)
                {
                    if (stock.cantidad == 0)
                    {
                        context.Stocks.Remove(stock);
                        await context.SaveChangesAsync();
                    }
                }
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(StockDTO stockDTO, int id)
        {

            var exist = await context.Stocks.AnyAsync(x => x.id == id);
            if (!exist)
            {
                return BadRequest($"el stock con el ID={id} no existe ");
            }
            var existe = await context.Productos.AnyAsync(x => x.id == stockDTO.ProductoId);
            if (!existe)
            {
                return NotFound($"El producto de id={stockDTO.ProductoId} no existe");
            }


            Stock entidad = new Stock();

            entidad.id = id;
            entidad.cantidad = stockDTO.cantidad;
            entidad.estado = stockDTO.estado;
            entidad.DepositoId = stockDTO.DepositoId;
            entidad.ProductoId = stockDTO.ProductoId;

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok("actualizado con exito");     
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Stocks.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return BadRequest($"El stock con el ID = {id} no se encuentra ");
            }

            context.Remove(new Stock() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

        public string errormessage;

    }
}
