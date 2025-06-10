using MatontineDigitalApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Services
{
  public class MyDB
  {
    private static MyDB _Instance;

    public static MyDB Instance
    {
      get
      {
        if (_Instance == null)
        {
          _Instance = new MyDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MaTontine.db3"));
        }
        return _Instance;
      }
    }


    readonly SQLiteAsyncConnection database;

    public MyDB(string dbPath)
    {
      database = new SQLiteAsyncConnection(dbPath);
      database.CreateTableAsync<ParameterEntity>().Wait();
    }

    public Task<ParameterEntity> GetParameterAsync()
    {
      return database.Table<ParameterEntity>()
                      .Where(i => i.ID == 1)
                      .FirstOrDefaultAsync();
    }

    public Task<int> SaveParameterAsync(bool rememberMe, bool useFingerPrint, Credentials cred)
    {
      var parm = new ParameterEntity
      {
        rememberMe = rememberMe,
        login = cred.plogin,
        password = cred.ppassword,
        useFingerPrint = useFingerPrint
      };

      return SaveParameterAsync(parm);
    }

    public async Task<int> SaveParameterAsync(ParameterEntity d)
    {
      var dbParams = await GetParameterAsync();

      if (dbParams != null)
      {
        d.ID = dbParams.ID;
        return await database.UpdateAsync(d);
      }
      else
      {
        d.ID = 1;
        return await database.InsertAsync(d);
      }
    }
    public Task<ParameterEntity> GetParameter()
    {
      try
      {
        return database.Table<ParameterEntity>()
          .FirstOrDefaultAsync();
      }
      catch (Exception ex)
      {

      }
      return null;


    }
  }
}
