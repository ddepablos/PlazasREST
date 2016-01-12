using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PlazasREST.Model;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.Entity.SqlServer;
using System.Data.Entity;

namespace PlazasREST
{

    public class ServiceREST : IServiceREST
    {
        private string SERVICE_NAME = "PlazasREST:";
        private string SERVICE_CODE = "0";
        private string SERVICE_DETAIL = "Transacción efectuada satisfactoriamente.";
        private string SERVICE_CODE_FALSE = "1";
        private string SERVICE_DETAIL_FALSE = "Ha ocurrido una excepción.";
        private string SERVICE_CODE_NOTFOUND = "2";
        private string SERVICE_DETAIL_NOTFOUND = "La consulta no ha retornado registros.";

        #region DummyMethods

        public Record GetTrue()
        {
            return new Record() { excode = SERVICE_CODE, exdetail = SERVICE_DETAIL };
        }

        public Record GetFalse()
        {
            return new Record() { excode = SERVICE_CODE_FALSE, exdetail = SERVICE_DETAIL_FALSE };
        }

        public Record GetNotFound()
        {
            return new Record() { excode = SERVICE_CODE_NOTFOUND, exdetail = SERVICE_DETAIL_NOTFOUND };
        }

        public Record GetEcho(string numero)
        {

            if (int.Parse(numero) > 9)
                numero = "0";

            string[] numbers = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };

            return new Record() { excode = numero, exdetail = SERVICE_NAME + numbers[int.Parse(numero)] };

        }

        public List<Record> GetVersion()
        {

            List<Record> version = new List<Record>();

            version.Add(new Record() { excode = "1.1.0", exdetail = "2016-01-12 - Release 1.1.0" });
            version.Add(new Record() { excode = "1.0.1", exdetail = "2016-01-11 - GetVersion : Incorporación de Listado de Versiones." });
            version.Add(new Record() { excode = "1.0.0", exdetail = "2015-10-26 - Versión Inicial" });

            return version;

        }

        #endregion

        #region PlazasMethods

        /* 
         * Nombre      :    GetClient
         * Descripción :    Consultar un único registro de cliente con los atributos del modelo WebPlazas. 
         * Parámetros  :    string keyword
         */
        public CCustomer GetClientByNumDoc(string keyword)
        {

            using (WebPlazasEntities context = new WebPlazasEntities())
            {

                try
                {
                    /* búsqueda por el campo docnumber */
                    var q = from c in context.Customers
                            join p in context.People on c.id equals p.customerid
                            where c.docnumber.Contains(keyword)
                            select new CCustomer()
                            {
                                id = c.id.ToString(),
                                docnumber = c.docnumber,
                                nationality = p.nationality + "",
                                name = c.name + "",
                                name2 = p.name2 + "",
                                lastname1 = p.lastname1 + "",
                                lastname2 = p.lastname2 + "",
                                birthdate = p.birthdate.ToString(), 
                                gender = p.gender.ToString() + "",
                                maritalstatus = p.maritalstatus.ToString() + "",
                                occupation = p.occupation + "",
                                phone1 = c.phone1 + "",
                                phone2 = c.phone2 + "",
                                phone3 = c.phone3 + "",
                                email = c.email,
                                facebook_account = "",
                                instagram_account = "",
                                twitter_account = "",
                                excode = SERVICE_CODE,
                                exdetail = SERVICE_DETAIL,
                                type = c.type + ""
                            };

                    return q.FirstOrDefault();  

                }
                catch (Exception e)
                {
                    return new CCustomer { excode = "100", exdetail = e.Source + " - Message : " + e.Message };
                }

            }

        }

        /* 
         * Nombre      :    GetClientByName
         * Descripción :    Consultar un conjunto de registros de clientes por el campo nombre del modelo WebPlazas. 
         * Parámetros  :    string keyword
         */
        //public List<CCustomer> GetClientByName(string keyword)
        public CCustomer GetClientByName(string keyword)
        {

            using (WebPlazasEntities context = new WebPlazasEntities())
            {

                try
                {

                    /* búsqueda por el campo docnumber */
                    var q = from c in context.Customers
                            join p in context.People on c.id equals p.customerid
                            where c.name.Contains(keyword)
                            select new CCustomer()
                            {
                                id = c.id.ToString(),
                                docnumber = c.docnumber,
                                nationality = p.nationality + "",
                                name = c.name + "",
                                name2 = p.name2 + "",
                                lastname1 = p.lastname1 + "",
                                lastname2 = p.lastname2 + "",
                                birthdate = p.birthdate.ToString(),
                                gender = p.gender.ToString() + "",
                                maritalstatus = p.maritalstatus.ToString() + "",
                                occupation = p.occupation + "",
                                phone1 = c.phone1 + "",
                                phone2 = c.phone2 + "",
                                phone3 = c.phone3 + "",
                                email = c.email,
                                excode = SERVICE_CODE,
                                exdetail = SERVICE_DETAIL,
                                type = c.type + ""
                            };

                    return q.FirstOrDefault();

                }
                catch (Exception e)
                {
                    return new CCustomer { excode = "100", exdetail = e.Source + " - Message : " + e.Message };
                }

            }

        }

        /* 
         * Nombre      :    UpdClient
         * Descripción :    Actualizar el registro de cliente del modelo WebPlazas, retornar True/Falso como respuesta de acción. 
         * Parámetros  :    string id, string type, string docnumber, string name, string name2, string lastname1, string lastname2, string phone1, string phone2, string maritalstatus, string gender
         */
        public Record UpdClient(string id, string docnumber, string nationality, string name, string name2, string lastname1, string lastname2, string birthdate, string gender, string maritalstatus, string occupation, string phone1, string phone2, string phone3, string email, string type)
        {

            try
            {

                using (WebPlazasEntities context = new WebPlazasEntities())
                {

                    var keyword = int.Parse(id);

                    var customer = context.Customers.SingleOrDefault(c => c.id == keyword);

                    var person = context.People.SingleOrDefault(p => p.customerid == customer.id);

                    if (customer != null && person != null)
                    {

                        DateTime datetime = DateTime.ParseExact(birthdate, "yyyyMMdd", CultureInfo.InvariantCulture);

                        customer.docnumber = docnumber;
                        person.nationality = nationality == "NULO" ? "" : nationality;
                        customer.name = name;
                        person.name2 = name2 == "NULO" ? "" : name2;
                        person.lastname1 = lastname1;
                        person.lastname2 = lastname2 == "NULO" ? "" : lastname2;
                        person.birthdate = datetime; 
                        person.gender = byte.Parse(gender);
                        person.maritalstatus = byte.Parse(maritalstatus);
                        person.occupation = occupation == "NULO" ? "" : occupation; 
                        customer.phone1 = phone1;
                        customer.phone2 = phone2 == "NULO" ? "" : phone2; 
                        customer.phone3 = phone3 == "NULO" ? "" : phone3; 
                        customer.email = email;
                        customer.type = byte.Parse(type);
                        customer.lastmodifydate = System.DateTime.Now;

                        context.Entry(customer).State = EntityState.Modified;
                        context.Entry(person).State = EntityState.Modified;

                        context.SaveChanges();

                        return GetTrue();
                     
                    }

                    return GetFalse();

                }

            }
            catch (Exception e)
            {

                return new Record() { excode = "100", exdetail = e.Message };
            }

        }

        /* 
         * Nombre      :    FindClientById
         * Descripción :    Retornar True/False si el id del cliente existe en el modelo WebPlazas. 
         * Parámetros  :    string keyword
         */
        public Record FindClientById(string keyword)
        {

            try
            {

                using (WebPlazasEntities context = new WebPlazasEntities())
                {

                    var findKey = int.Parse(keyword);
                    var result = context.Customers.SingleOrDefault(c => c.id == findKey);

                    if (result != null)
                    {
                        return GetTrue();
                    }
                    else
                    {
                        return GetNotFound();
                    }
                   
                }

            }
            catch (Exception e)
            {
                return new Record() { excode = SERVICE_CODE_FALSE, exdetail = e.Source + ": " + e.Message };
            }

        }

        /* 
         * Nombre      :    FindClientByNumDoc
         * Descripción :    Retornar True/False si el numero del documento del cliente existe en el modelo WebPlazas. 
         * Parámetros  :    string keyword
         */
        public Record FindClientByNumDoc(string keyword)
        {
            try
            {

            using (WebPlazasEntities context = new WebPlazasEntities())
            {

                var result = context.Customers.SingleOrDefault(c => c.docnumber == keyword);

                if (result != null)
                {
                    return GetTrue();
                }
                else
                {
                    return GetNotFound();
                }

            }

            }
            catch (Exception e)
            {
                return new Record() { excode = SERVICE_CODE_FALSE, exdetail = e.Source + ": " + e.Message };
            }

        }

        /* 
         * Nombre      :    GetClients
         * Descripción :    Retornar objeto lista de clientes por criterio de búsqueda (cédula/nombre/correo). 
         * Parámetros  :    string keyword
         */
        public List<CCustomers> GetClients(string keyword)
        {

            try
            {

                using (WebPlazasEntities context = new WebPlazasEntities())
                {

                    if (Regex.IsMatch(keyword, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")) 
                    {
                        // búsqueda por correo electrónico.
                        var q = from c in context.Customers
                                join p in context.People on c.id equals p.customerid
                                where c.email == keyword
                                select new CCustomers()
                                {
                                    docnumber = c.docnumber,
                                    name = c.name + "",
                                    lastname1 = p.lastname1 + "",
                                    email = c.email,
                                    exnumber = SERVICE_CODE,
                                    exdetail = SERVICE_DETAIL
                                };

                        return q.ToList(); 
  
                    }
                    else if( Regex.IsMatch( keyword , "^[a-zA-Z]*$" ) )
                    {
                        // búsqueda por nombre del cliente.
                        var q = from c in context.Customers
                                join p in context.People on c.id equals p.customerid
                                where c.name.ToLower().Contains(keyword.ToLower()) || p.lastname1.ToLower().Contains(keyword.ToLower())
                                select new CCustomers()
                                {
                                    docnumber = c.docnumber,
                                    name = c.name + "",
                                    lastname1 = p.lastname1 + "",
                                    email = c.email,
                                    exnumber = SERVICE_CODE,
                                    exdetail = SERVICE_DETAIL
                                };

                        return q.ToList();

                    }
                    else 
                    {
                        // búsqueda por número de documento.
                        var q = from c in context.Customers
                                join p in context.People on c.id equals p.customerid
                                where c.docnumber.Contains(keyword)
                                select new CCustomers()
                                {
                                    docnumber = c.docnumber,
                                    name = c.name + "",
                                    lastname1 = p.lastname1 + "",
                                    exnumber = SERVICE_CODE,
                                    exdetail = SERVICE_DETAIL
                                };

                        return q.ToList();

                    }

                }

            }
            catch (Exception e)
            {
                //return null;
                List<CCustomers> exception = new List<CCustomers>();

                exception.Add(new CCustomers() { exnumber = e.Source + ": " + e.Message + " - " + e.InnerException });

                return exception;
            }

        }

        /* 
         * Nombre      :    GetSucursales
         * Descripción :    Retornar objeto lista de sucursales del modelo WebPlazas. 
         * Parámetros  :    N/A
         */
        public List<CStore> GetSucursales()
        {

            try
            {

                using (WebPlazasEntities context = new WebPlazasEntities())
                {

                    var result = (from store in context.Stores 
                                  select new CStore 
                                  { 
                                    id = store.id.ToString(), 
                                    name = store.name 
                                  }).ToList();

                    return result;

                }

            }
            catch (Exception)
            {
                return null; 
            }

        }

        #endregion

    }

}
