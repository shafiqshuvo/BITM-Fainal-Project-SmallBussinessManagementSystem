﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileError.Model.Model;
using CompileError.Repository.Repository;

namespace CompileError.Manager.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);

        }

        public Customer GetById(int id)
        {

            return _customerRepository.GetById(id);
        }



        public bool Delete(int id)
        {

            return _customerRepository.Delete(id);
        }

        public bool UpdateLoyalty(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}