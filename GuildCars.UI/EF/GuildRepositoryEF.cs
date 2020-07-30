using GuildCars.Data;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GuildCars.UI.EF
{
    public class GuildRepositoryEF : IGuildRepository
    {
        private readonly ApplicationDbContext _context;

        public GuildRepositoryEF()
        {
            _context = new ApplicationDbContext();
        }

        public GuildRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int? id)
        {
            return _context.Cars.Find(id);
        }

        public void InsertCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> Search(ListingSearchParameters parameters)
        {
            List<Car> cars = new List<Car>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 10 * FROM Car JOIN Make on Make.MakeID = Car.MakeID " +
                    "JOIN Model on Model.ModelID = Car.ModelID " +
                    "JOIN Condition on Condition.ConditionID = Car.ConditionID " +
                    "JOIN BodyStyle on BodyStyle.BodyStyleID = Car.BodyStyleID " +
                    "JOIN Transmission on Transmission.TransmissionID = Car.TransmissionID " +
                    "JOIN ExteriorColor on ExteriorColor.ExteriorColorID = Car.ExteriorColorID " +
                    "JOIN InteriorColor on InteriorColor.InteriorColorID = Car.InteriorColorID ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (parameters.Mileage == "used")
                {
                    query += "AND Car.Mileage != 'New' ";
                }
                if (parameters.Mileage == "new")
                {
                    query += "AND Car.Mileage = 'New' ";
                }
                if (parameters.OnSale == "true")
                {
                    query += "AND Car.OnSale = '1' ";
                }

                if (!string.IsNullOrEmpty(parameters.Make))
                {
                    query += "AND Make.MakeName LIKE @makeName ";
                    cmd.Parameters.AddWithValue("@makeName", parameters.Make + '%');
                }

                if (!string.IsNullOrEmpty(parameters.Model))
                {
                    query += "AND Model.ModelName LIKE @modelName ";
                    cmd.Parameters.AddWithValue("@modelName", parameters.Make + '%');
                }

                if (!string.IsNullOrEmpty(parameters.MinPrice) || !string.IsNullOrEmpty(parameters.MaxPrice))
                {
                    query += "AND Car.SalePrice BETWEEN @minPrice AND  @maxPrice ";
                    cmd.Parameters.AddWithValue("@minPrice", parameters.MinPrice);
                    cmd.Parameters.AddWithValue("@maxPrice", parameters.MaxPrice);
                }

                if (parameters.MinYear != "Any" && parameters.MaxYear != "Any")
                {
                    query += "AND [Car].[Year] BETWEEN @minYear AND  @maxYear ";
                    cmd.Parameters.AddWithValue("@minYear", parameters.MinPrice);
                    cmd.Parameters.AddWithValue("@maxYear", parameters.MaxPrice);
                }

                if (parameters.MinYear != "Any" && parameters.MaxYear == "Any")
                {
                    query += "AND [Car].[Year] >= @minYear ";
                    cmd.Parameters.AddWithValue("@minYear", parameters.MinPrice);
                }

                if (parameters.MinYear == "Any" && parameters.MaxYear != "Any")
                {
                    query += "AND [Car].[Year] <= @maxYear ";
                    cmd.Parameters.AddWithValue("@maxYear", parameters.MaxYear);
                }

                cmd.CommandText = query;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car row = new Car();

                        row.CarID = (int)dr["CarID"];
                        row.OnSale = (bool)dr["OnSale"];
                        row.IsInStock = (bool)dr["IsInStock"];
                        row.Make = new Make();
                        row.Make.MakeID = (int)dr["MakeID"];
                        row.Make.MakeName = dr["MakeName"].ToString();
                        row.Model = new Model();
                        row.Model.ModelID = (int)dr["ModelID"];
                        row.Model.ModelName = dr["ModelName"].ToString();
                        row.Condition = new Condition();
                        row.Condition.ConditionID = (int)dr["ConditionID"];
                        row.Condition.ConditionType = dr["ConditionType"].ToString();
                        row.Year = (int)dr["Year"];
                        row.BodyStyle = new BodyStyle();
                        row.BodyStyle.BodyStyleID = (int)dr["BodyStyleID"];
                        row.BodyStyle.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.Transmission = new Transmission();
                        row.Transmission.TransmissionID = (int)dr["TransmissionID"];
                        row.Transmission.TransmissionType = dr["TransmissionType"].ToString();
                        row.ExteriorColor = new ExteriorColor();
                        row.ExteriorColor.ExteriorColorID = (int)dr["ExteriorColorID"];
                        row.ExteriorColor.Color = dr["Color"].ToString();
                        row.InteriorColor = new InteriorColor();
                        row.InteriorColor.InteriorColorID = (int)dr["InteriorColorID"];
                        row.InteriorColor.Color = dr["Color"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.DateAdded = dr["DateAdded"].ToString();
                        row.Photo = dr["Photo"].ToString();

                        cars.Add(row);
                    }
                }
            }

            return cars;
        }

        public void UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
        }
    }
}