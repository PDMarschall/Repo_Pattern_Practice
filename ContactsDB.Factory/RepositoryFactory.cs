using System;
using Repo
using Repo_Pattern_Practice.Repository;

namespace ContactsDB.Factory
{
    public class RepositoryFactory
    {
        public static IRepository GetRepository(string repositoryType)
        {
            IRepository repository = null;

            switch (repositoryType)
            {
                case "Service":
                    repository = new ServiceRepository();
                    break;
                case "CSV":
                    repository = new CSVRepository();
                    break;
                case "SQL":
                    repository = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repository type");
            }

            return repository;
        }
}
