using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo_Pattern_Practice.Repository;
using Repo_Pattern_Practice.Models;

namespace Repo_Pattern_Practice
{
    public static class RepositoryFactory
    {
        public static IRepository<T> GetRepository<T>(T obj)
        {
            IRepository<T> repository = null;


            switch (obj)
            {
                case Addresse:
                    repository = new AddressRepository();
                    break;
                case Zipcode:
                    repository = new ZipcodeRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repository type");
            }

            return repository;
        }
    }
