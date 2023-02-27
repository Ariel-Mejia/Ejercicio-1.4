using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tarea4.Models;

namespace Tarea4.Controllers
{
    public class DBInformacion
    {
        readonly SQLiteAsyncConnection dbase;
        public DBInformacion(String dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            // Crearemos las tablas de la base de datos 
            dbase.CreateTableAsync<Informacion>(); //Creado la tabla de Empleado


        }

        #region OperacionesEmple
        // CRUD - Create - Read - Update - Delete
        // Create
        public Task<int> EmpleSave(Informacion emple)
        {
            if (emple.codigo != 0)
            {
                return dbase.UpdateAsync(emple); // Update
            }
            else
            {
                return dbase.InsertAsync(emple); ;// Insert
            }
        }

        // Read
        public Task<List<Informacion>> obtenerListaEmple()
        {
            return dbase.Table<Informacion>().ToListAsync();
        }

        // Read V2
        public Task<Informacion> obtenerEmple(int pid)
        {
            return dbase.Table<Informacion>()
                .Where(i => i.codigo == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> EmpleDelete(Informacion emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion OperacionesEmple
    }
}
