using Homework3.Models;
using Homework3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly ProductService productService;

    public ProductController(ProductService productService)
    {
        this.productService = productService;
    }

    public IActionResult Index()
    {
        var products = productService.GetAllProducts();
        return View(products);
    }

    public IActionResult Edit(int id)
    {
        var product = productService.GetProductById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product editedProduct)
    {
        productService.UpdateProduct(editedProduct);
        return RedirectToAction("Index");
    }

    public IActionResult Remove(int id)
    {
        var product = productService.GetProductById(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult RemoveConfirmed(int id)
    {
        productService.RemoveProduct(id);
        return RedirectToAction("Index");
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product newProduct)
    {
        productService.AddProduct(newProduct);
        return RedirectToAction("Index");
    }
}

