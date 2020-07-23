using GuildCars.Data.Interfaces;
using GuildCars.Models.Entity;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class GuildRepositoryADO : IGuildRepository
    {
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsSelectAll", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car row = new Car();

                        row.CarID = (int)dr["CarID"];
                        row.OnSale = (bool)dr["OnSale"];
                        row.IsInStock = (bool)dr["IsInStock"];
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.ConditionID = (int)dr["ConditionID"];
                        row.Year = (int)dr["Year"];
                        row.BodyStyleID = (int)dr["BodyStyleID"];
                        row.TransmissionID = (int)dr["TransmissionID"];
                        row.ExteriorColorID = (int)dr["ExteriorColorID"];
                        row.InteriorColorID = (int)dr["InteriorColorID"];
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

        public Car GetCarById(int? id)
        {
            Car row = null;

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarID", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        row = new Car();
                        row.CarID = (int)dr["CarID"];
                        row.OnSale = (bool)dr["OnSale"];
                        row.IsInStock = (bool)dr["IsInStock"];
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.ConditionID = (int)dr["ConditionID"];
                        row.Year = (int)dr["Year"];
                        row.BodyStyleID = (int)dr["BodyStyleID"];
                        row.TransmissionID = (int)dr["TransmissionID"];
                        row.ExteriorColorID = (int)dr["ExteriorColorID"];
                        row.InteriorColorID = (int)dr["InteriorColorID"];
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Description = dr["Description"].ToString();
                        row.DateAdded = dr["DateAdded"].ToString();
                        row.Photo = dr["Photo"].ToString();
                    }
                }

                return row;
            }
        }

        public void InsertCar(Car car)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsInsert", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CarID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@UserID", car.UserID);
                cmd.Parameters.AddWithValue("@OnSale", car.OnSale);
                cmd.Parameters.AddWithValue("@IsInStock", car.IsInStock);
                cmd.Parameters.AddWithValue("@MakeID", car.Make.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", car.Model.ModelID);
                cmd.Parameters.AddWithValue("@ConditionID", car.Condition.ConditionID);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@BodyStyleID", car.BodyStyle.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", car.Transmission.TransmissionID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", car.ExteriorColor.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", car.InteriorColor.InteriorColorID);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@DateAdded", car.DateAdded);
                cmd.Parameters.AddWithValue("@Photo", car.Photo);               

                conn.Open();

                cmd.ExecuteNonQuery();

                car.CarID = (int)param.Value;
            }
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

                if (!string.IsNullOrEmpty(parameters.Make))
                {
                    if (parameters.Mileage == "used")
                    {
                        query += "AND Make.MakeName LIKE @makeName AND Car.Mileage != 'New' ";
                        cmd.Parameters.AddWithValue("@makeName", parameters.Make + '%');
                    }
                    else if (parameters.Mileage == "new")
                    {
                        query += "AND Make.MakeName LIKE @makeName AND Car.Mileage = 'New' ";
                        cmd.Parameters.AddWithValue("@makeName", parameters.Make + '%');
                    }
                    else if (parameters.OnSale == "true")
                    {
                        query += "AND Make.MakeName LIKE @makeName AND Car.OnSale = '1' ";
                        cmd.Parameters.AddWithValue("@makeName", parameters.Make + '%');
                    }
                    else
                    {
                        query += "AND Make.MakeName LIKE @makeName ";
                        cmd.Parameters.AddWithValue("@makeName", parameters.Make + '%');
                    }
                }

                if (!string.IsNullOrEmpty(parameters.Model))
                {
                    if (parameters.Mileage == "used")
                    {
                        query += "AND Model.ModelName LIKE @modelName AND Car.Mileage != 'New' ";
                        cmd.Parameters.AddWithValue("@modelName", parameters.Make + '%');
                    }
                    else if (parameters.Mileage == "new")
                    {
                        query += "AND Model.ModelID LIKE @modelName AND Car.Mileage = 'New' ";
                        cmd.Parameters.AddWithValue("@modelName", parameters.Make + '%');
                    }
                    else if (parameters.OnSale == "true")
                    {
                        query += "AND Make.ModelName LIKE @modelName AND Car.OnSale = '1' ";
                        cmd.Parameters.AddWithValue("@modelName", parameters.Make + '%');
                    }
                    else
                    {
                        query += "AND Model.ModelName LIKE @modelName ";
                        cmd.Parameters.AddWithValue("@modelName", parameters.Make + '%');
                    }
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
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsUpdate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OnSale", car.OnSale);
                cmd.Parameters.AddWithValue("@IsInStock", car.IsInStock);
                cmd.Parameters.AddWithValue("@MakeID", car.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", car.ModelID);
                cmd.Parameters.AddWithValue("@ConditionID", car.ConditionID);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@BodyStyleID", car.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", car.TransmissionID);
                cmd.Parameters.AddWithValue("@ExteriorColorID", car.ExteriorColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", car.InteriorColorID);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@DateAdded", car.DateAdded);
                cmd.Parameters.AddWithValue("@Photo", car.Photo);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
