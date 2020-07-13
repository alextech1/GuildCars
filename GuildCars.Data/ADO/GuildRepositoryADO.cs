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

                car.CarID = (int)param.Value;
            }
        }

        public IEnumerable<Car> Search(ListingSearchParameters parameters)
        {
            throw new NotImplementedException();
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
