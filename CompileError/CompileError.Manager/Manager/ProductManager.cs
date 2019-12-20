using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileError.Model.Model;
using CompileError.Repository.Repository;

namespace CompileError.Manager.Manager
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();
        public bool Add(Product product)
        {
            return _productRepository.Add(product);

        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

    }
}
