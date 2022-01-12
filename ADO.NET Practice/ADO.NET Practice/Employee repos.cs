using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET_Practice
{
    class Employee_repos
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;";
       
        public void GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                Employee_Model employee = new Employee_Model();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllemployee_payroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            employee.id = dr.GetInt32(0);
                            employee.name = dr.GetString(1);
                            employee.salary = dr.GetInt64(2);
                            employee.start_date = dr.GetString(3);
                            employee.phone = dr.GetInt32(4);
                            employee.department = dr.GetInt32(5);
                            employee.address = dr.GetString(6);
                            employee.basicPay = dr.GetFloat(7);
                            employee.deduction = dr.GetFloat(8);
                            employee.taxablePay = dr.GetFloat(9);
                            employee.netpay = dr.GetFloat(10);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", employee.id, employee.name
                                , employee.salary, employee.start_date, employee.phone, employee.department, employee.address, employee.basicPay,
                                employee.deduction, employee.taxablePay, employee.netpay);

                        }
                        dr.Close();
                        connection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void AddEmployee(Employee_Model Model)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    //Creating a stored Procedure for adding employees into database
                    SqlCommand com = new SqlCommand("spAddEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@name", Model.name);
                    com.Parameters.AddWithValue("@salary", Model.salary);
                    com.Parameters.AddWithValue("@start_date", Model.start_date);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                   // Console.WriteLine("Record Successfully Inserted On Table");
                    connection.Close();
                    GetAllEmployee();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateEmployee(double basicPay, string name)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand com = new SqlCommand("spUpdateEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@name", name);
                    com.Parameters.AddWithValue("@basicPay", basicPay);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                    Console.WriteLine("Record Successfully Updated On Table");
                    connection.Close();
                    GetAllEmployee();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
     /*  public void RetrieveAllEmployeee()
        {
            try
            {
                using (connection)
                {
                    SqlCommand com = new SqlCommand("spRetrieveAllEmployeeForParticularRange", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    foreach(var result in DataTable.employee_payroll )
                    {

                    }
                }
            }*/
        
    }
}
