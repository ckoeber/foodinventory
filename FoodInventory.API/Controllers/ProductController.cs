using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FoodInventory.Data;
using FoodInventory.Data.Models;

namespace FoodInventory.API.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpGet]
        public HttpResponseMessage Get([FromUri]int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    //Get all products
                    var dbListingOfProductsToReturn = _unitOfWork.ProductRepository.Get().Where(p => p.DeletedDate == null);
                    var tempListToReturn = from p in dbListingOfProductsToReturn
                                           select new FoodInventory.Data.Models.DTOs.ProductDTO()
                                                                                        {
                                                                                            ID = p.ID,
                                                                                            Name = p.Name,
                                                                                            Description = p.Description,
                                                                                            PurchasePrice = p.PurchasePrice,
                                                                                            SalesPrice = p.SalesPrice,
                                                                                            SpoilDate = p.SpoilDate,
                                                                                            UnitsAvailable = p.UnitsAvailable
                                                                                        };
                    return Request.CreateResponse(HttpStatusCode.OK, tempListToReturn.ToList());
                } else
                {
                    //Get specified product
                    var dbProductToReturn = _unitOfWork.ProductRepository.Get().Where(p => p.ID == id).FirstOrDefault();
                    var finalProductToReturn = new FoodInventory.Data.Models.DTOs.ProductDTO
                    {
                        ID = dbProductToReturn.ID,
                        Name = dbProductToReturn.Name,
                        Description = dbProductToReturn.Description,
                        PurchasePrice = dbProductToReturn.PurchasePrice,
                        SalesPrice = dbProductToReturn.SalesPrice,
                        SpoilDate = dbProductToReturn.SpoilDate,
                        UnitsAvailable = dbProductToReturn.UnitsAvailable
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, finalProductToReturn);
                }
            } catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.ToString());
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] FoodInventory.Data.Models.DTOs.ProductDTO productToAddOrEdit)
        {
            try
            {
                var messageToReturn = "";
                if (productToAddOrEdit.ID == 0)
                {
                    //Add this product. First check to see if product name might have been added already.

                    var productToAdd = _unitOfWork.ProductRepository.Get().Where(p => p.Name.Trim().ToUpper() == productToAddOrEdit.Name.Trim().ToUpper()).FirstOrDefault();
                    
                    //Doesn't exist, add.
                    if (productToAdd == null)
                    {
                        productToAdd = new Product
                        {
                            Name = productToAddOrEdit.Name,
                            Description = productToAddOrEdit.Description,
                            PurchasePrice = productToAddOrEdit.PurchasePrice,
                            SalesPrice = productToAddOrEdit.SalesPrice,
                            DeletedDate = productToAddOrEdit.DeletedDate,
                            SpoilDate = productToAddOrEdit.SpoilDate,
                            UnitsAvailable = productToAddOrEdit.UnitsAvailable
                        };
                        _unitOfWork.ProductRepository.Insert(productToAdd);
                        _unitOfWork.Save();
                        messageToReturn = "Added product (" + productToAdd.Name + ") with ID (" + productToAdd.ID + ").";
                    } else
                    {
                        //Product exists, must be undeleted
                        productToAdd.Name = productToAddOrEdit.Name;
                        productToAdd.Description = productToAddOrEdit.Description;
                        productToAdd.PurchasePrice = productToAddOrEdit.PurchasePrice;
                        productToAdd.SalesPrice = productToAddOrEdit.SalesPrice;
                        productToAdd.DeletedDate = productToAddOrEdit.DeletedDate;
                        productToAdd.SpoilDate = productToAddOrEdit.SpoilDate;
                        productToAdd.UnitsAvailable = productToAddOrEdit.UnitsAvailable;
                        productToAdd.DeletedDate = null;
                        _unitOfWork.ProductRepository.Update(productToAdd);
                        _unitOfWork.Save();
                        messageToReturn = "Added product (" + productToAdd.Name + ") with ID (" + productToAdd.ID +") which was previously deleted.";
                    }
                } else
                {
                    var productToEdit = _unitOfWork.ProductRepository.Get().Where(p => p.ID == productToAddOrEdit.ID).FirstOrDefault();
                    if (productToEdit == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "The product (" + productToAddOrEdit.Name + ") with ID (" + productToAddOrEdit.ID + ") does not exist.");
                    } else
                    {
                        //Edit this product.
                        productToEdit.Name = productToAddOrEdit.Name;
                        productToEdit.Description = productToAddOrEdit.Description;
                        productToEdit.PurchasePrice = productToAddOrEdit.PurchasePrice;
                        productToEdit.SalesPrice = productToAddOrEdit.SalesPrice;
                        productToEdit.DeletedDate = productToAddOrEdit.DeletedDate;
                        productToEdit.SpoilDate = productToAddOrEdit.SpoilDate;
                        productToEdit.UnitsAvailable = productToAddOrEdit.UnitsAvailable;
                        productToEdit.DeletedDate = null;
                        _unitOfWork.ProductRepository.Update(productToEdit);
                        _unitOfWork.Save();
                        messageToReturn = "Edited product (" + productToEdit.Name + ") with ID (" + productToEdit.ID + ").";
                    }
                    
                }
                return Request.CreateResponse(HttpStatusCode.OK, messageToReturn);
            } catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.ToString());
            }
        }

        [HttpGet,HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                var productToDelete = _unitOfWork.ProductRepository.Get().Where(p => p.ID == id).FirstOrDefault();
                if (productToDelete == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The product you are trying to delete does not exist.");
                }
                else
                {
                    productToDelete.DeletedDate = DateTime.Now;
                    _unitOfWork.ProductRepository.Update(productToDelete);
                    _unitOfWork.Save();
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted product (" + productToDelete.Name + ") with ID (" + productToDelete.ID + ").");
                }
            } catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.ToString());
            }
        } 
    }
}
