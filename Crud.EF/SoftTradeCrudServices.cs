using Crud.domain.Model;
using Crud.domain.Services;
using Crud.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EF
{
    public class SoftTradeCrudServices : ICrud
    {
        private readonly IDataService<Client> _crudServices;
        public SoftTradeCrudServices()
        {
            _crudServices = new GenericDataService<Client>(new ClientContextFactory());
        }
        public async Task<Client> AddBrand(string stname, string status)
        {
            try
            {
                if (stname == string.Empty)
                {
                    throw new Exception("Student Name Cannot be Empty");
                }
                else
                {
                    Client br = new Client
                    {
                        Name = stname,
                        Status = status
                    };
                    return await _crudServices.Create(br);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Client delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<Client>> ListBrands()
        {
            try
            {
                return (ICollection<Client>)await _crudServices.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<Client> SearchBrandbyID(int id)
        {
            try
            {
                return _crudServices.Get(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Client>> SearchBrandByName(string stname)
        {
            try
            {
                var listbrand = await ListBrands();
                return listbrand.Where(x => x.Name.StartsWith(stname)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Client> UpdateBrand(int id, string stname, string status)
        {
            try
            {
                Client br = await SearchBrandbyID(id);
                br.Name = stname;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
