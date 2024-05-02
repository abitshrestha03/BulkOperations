using Day12First.Data;
using Day12First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day12First.Controllers
{
    public class FruitController:Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public FruitController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Fruit> fruits = _dbContext.Fruits.Where(f=>f.IsDeleted==false).ToList();
            return View(fruits);
        }
        [HttpPost]
        public IActionResult Delete(List<Fruit> Fruits)
        {
            if (ModelState.IsValid)
                {
                foreach (var fruit in Fruits)
                {
                    if (fruit.IsChecked && fruit.Id != 0)
                    {
                        var existingFruit = _dbContext.Fruits.FirstOrDefault(f => f.Id == fruit.Id);
                        if (existingFruit != null)
                        {
                            existingFruit.IsDeleted = true;
                            _dbContext.Fruits.Update(existingFruit);
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(List<Fruit> Fruits)
        {
            if (ModelState.IsValid)
            {
                foreach(var fruit in Fruits)
                {
                    if(fruit.IsChecked && fruit.Id != 0)
                    {
                        var existingFruit = _dbContext.Fruits.FirstOrDefault(f => f.Id == fruit.Id);
                        if (existingFruit != null)
                        {
                            existingFruit.Name = fruit.Name;
                            existingFruit.Price = fruit.Price;
                            existingFruit.HarvestSeason = fruit.HarvestSeason;
                            existingFruit.Categories = fruit.Categories;
                            _dbContext.SaveChanges();
                        }
                    }
                }
                var newFruits = Fruits.Where(f => f?.Id == 0).ToList();
                _dbContext.Fruits.AddRange(newFruits);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
