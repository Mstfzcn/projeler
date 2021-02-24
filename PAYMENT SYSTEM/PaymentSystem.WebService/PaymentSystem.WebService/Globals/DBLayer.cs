using PaymentSystem.WebService.Constants;
using PaymentSystem.WebService.Models;
using PaymentSystem.WebService.Models.Request;
using PaymentSystem.WebService.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Globals
{
    public class DBLayer
    {
        public static OfficerCheckResponse GetUserOfficerCheck(OfficerCheckRequest request)
        {
            OfficerCheckResponse response = new OfficerCheckResponse();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_USER_OFFICER_CHECK, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@USER_CODE", request.UserCode);
                        cmd.Parameters.AddWithValue("@USER_PASSWORD", request.UserPassword);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if(table.Rows.Count > 0)
                        {
                            response.OfficerId = Convert.ToInt32(table.Rows[0]["OFFICER_ID"]);
                            response.UserCode = table.Rows[0]["USER_CODE"].ToString();
                            response.Name = table.Rows[0]["NAME"].ToString();
                            response.Surname = table.Rows[0]["SURNAME"].ToString();
                            response.InsertUser = table.Rows[0]["INSERT_USER"].ToString();
                            response.InsertDate = Convert.ToDateTime(table.Rows[0]["INSERT_DATE"].ToString());
                            response.UpdateUser = table.Rows[0]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[0]["UPDATE_DATE"].ToString()))
                                response.UpdateDate = Convert.ToDateTime(table.Rows[0]["UPDATE_DATE"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static SubscriberCheckResponse GetUserSubscriberCheck(SubscriberCheckRequest request)
        {
            SubscriberCheckResponse response = new SubscriberCheckResponse();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_USER_SUBSCRIBER_CHECK, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDENTIFICATION_TAX_NUMBER", request.IdentificationTaxNumber);
                        cmd.Parameters.AddWithValue("@USER_PASSWORD", request.UserPassword);
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_TYPE_ID", request.SubscriberTypeId);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            response.SubscriberId = Convert.ToInt32(table.Rows[0]["SUBSCRIBER_ID"]);
                            response.Name = table.Rows[0]["NAME"].ToString();
                            response.Surname = table.Rows[0]["SURNAME"].ToString();
                            response.SubscriberTypeId = Convert.ToInt32(table.Rows[0]["SUBSCRIBER_TYPE_ID"]);
                            response.IdentificationTaxNumber = table.Rows[0]["IDENTIFICATION_TAX_NUMBER"].ToString();
                            response.SubscriptionId = Convert.ToInt32(table.Rows[0]["SUBSCRIPTION_ID"]);
                            response.InsertUser = table.Rows[0]["INSERT_USER"].ToString();
                            response.InsertDate = Convert.ToDateTime(table.Rows[0]["INSERT_DATE"].ToString());
                            response.UpdateUser = table.Rows[0]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[0]["UPDATE_DATE"].ToString()))
                                response.UpdateDate = Convert.ToDateTime(table.Rows[0]["UPDATE_DATE"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static SubscriberResponse GetUserSubscriber(SubscriberRequest request)
        {
            SubscriberResponse response = new SubscriberResponse();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_USER_SUBSCRIBER, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IDENTIFICATION_TAX_NUMBER", request.IdentificationTaxNumber);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            response.SubscriberId = Convert.ToInt32(table.Rows[0]["SUBSCRIBER_ID"]);
                            response.Name = table.Rows[0]["NAME"].ToString();
                            response.Surname = table.Rows[0]["SURNAME"].ToString();
                            response.SubscriberTypeId = Convert.ToInt32(table.Rows[0]["SUBSCRIBER_TYPE_ID"]);
                            response.SubscriberTypeName = table.Rows[0]["SUBSCRIBER_TYPE_NAME"].ToString();
                            response.IdentificationTaxNumber = table.Rows[0]["IDENTIFICATION_TAX_NUMBER"].ToString();
                            response.SubscriptionId = Convert.ToInt32(table.Rows[0]["SUBSCRIPTION_ID"]);
                            response.SubscriptionType = table.Rows[0]["SUBSCRIPTION_TYPE"].ToString();
                            response.Active = Convert.ToBoolean(table.Rows[0]["ACTIVE"]);
                            response.InsertUser = table.Rows[0]["INSERT_USER"].ToString();
                            response.InsertDate = Convert.ToDateTime(table.Rows[0]["INSERT_DATE"].ToString());
                            response.UpdateUser = table.Rows[0]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[0]["UPDATE_DATE"].ToString()))
                                response.UpdateDate = Convert.ToDateTime(table.Rows[0]["UPDATE_DATE"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static bool InsertSubscriber(InsertSubscriberRequest request)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_INSERT_SUBSCRIBER, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_TYPE_ID", request.SubscriberTypeId);
                        cmd.Parameters.AddWithValue("@IDENTIFICATION_TAX_NUMBER", request.IdentificationTaxNumber);
                        cmd.Parameters.AddWithValue("@USER_PASSWORD", request.UserPassword);
                        cmd.Parameters.AddWithValue("@NAME", request.Name);
                        cmd.Parameters.AddWithValue("@SURNAME", request.Surname);
                        cmd.Parameters.AddWithValue("@SUBSCRIPTION_ID", request.SubscriptionId);
                        cmd.Parameters.AddWithValue("@INSERT_USER", request.InsertUser);

                        var ReturnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                        ReturnParameter.Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(ReturnParameter.Value) == 0 ? false : true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return result;
        }

        public static bool UpdateInvoicePay(UpdateInvoicePayRequest request)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_UPDATE_INVOICE_PAY, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@INVOICE_ID", request.InvoiceId);
                        cmd.Parameters.AddWithValue("@UPDATE_USER", request.UpdateUser);

                        var ReturnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                        ReturnParameter.Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(ReturnParameter.Value) == 0 ? false : true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return result;
        }

        public static List<InvoiceAllUnpaidResponse> GetInvoiceAllUnpaid(int SubscriberId)
        {
            List<InvoiceAllUnpaidResponse> response = new List<InvoiceAllUnpaidResponse>();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_INVOICE_ALL_UNPAID, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_ID", SubscriberId);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        for(int i = 0; i < table.Rows.Count; i++)
                        {
                            InvoiceAllUnpaidResponse item = new InvoiceAllUnpaidResponse();
                            item.InvoiceId = Convert.ToInt32(table.Rows[i]["INVOICE_ID"]);
                            item.SubscriberId = Convert.ToInt32(table.Rows[i]["SUBSCRIBER_ID"]);
                            item.NameSurname = table.Rows[i]["NAME_SURNAME"].ToString();
                            item.SubscriptionId = Convert.ToInt32(table.Rows[i]["SUBSCRIPTION_ID"]);
                            item.SubscriptionType = table.Rows[i]["SUBSCRIPTION_TYPE"].ToString();
                            item.InvoiceAmount = Convert.ToInt32(table.Rows[i]["INVOICE_AMOUNT"]);
                            item.CutOffDate = Convert.ToDateTime(table.Rows[i]["CUT_OFF_DATE"].ToString());
                            item.FinalPaymentDate = Convert.ToDateTime(table.Rows[i]["FINAL_PAYMENT_DATE"].ToString());
                            item.InsertUser = table.Rows[i]["INSERT_USER"].ToString();
                            item.InsertDate = Convert.ToDateTime(table.Rows[i]["INSERT_DATE"].ToString());
                            item.UpdateUser = table.Rows[i]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[i]["UPDATE_DATE"].ToString()))
                                item.UpdateDate = Convert.ToDateTime(table.Rows[i]["UPDATE_DATE"].ToString());
                            response.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static List<InvoicePaidResponse> GetInvoicePaid(int SubscriberId)
        {
            List<InvoicePaidResponse> response = new List<InvoicePaidResponse>();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_INVOICE_PAID, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_ID", SubscriberId);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            InvoicePaidResponse item = new InvoicePaidResponse();
                            item.InvoiceId = Convert.ToInt32(table.Rows[i]["INVOICE_ID"]);
                            item.SubscriberId = Convert.ToInt32(table.Rows[i]["SUBSCRIBER_ID"]);
                            item.NameSurname = table.Rows[i]["NAME_SURNAME"].ToString();
                            item.SubscriptionId = Convert.ToInt32(table.Rows[i]["SUBSCRIPTION_ID"]);
                            item.SubscriptionType = table.Rows[i]["SUBSCRIPTION_TYPE"].ToString();
                            item.InvoiceAmount = Convert.ToInt32(table.Rows[i]["INVOICE_AMOUNT"]);
                            item.CutOffDate = Convert.ToDateTime(table.Rows[i]["CUT_OFF_DATE"].ToString());
                            item.FinalPaymentDate = Convert.ToDateTime(table.Rows[i]["FINAL_PAYMENT_DATE"].ToString());
                            item.InsertUser = table.Rows[i]["INSERT_USER"].ToString();
                            item.InsertDate = Convert.ToDateTime(table.Rows[i]["INSERT_DATE"].ToString());
                            item.UpdateUser = table.Rows[i]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[i]["UPDATE_DATE"].ToString()))
                                item.UpdateDate = Convert.ToDateTime(table.Rows[i]["UPDATE_DATE"].ToString());
                            response.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static bool CloseSubscription(CloseSubscriptionRequest request)
        {
            bool result = false;

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_CLOSE_SUBSCRIPTION, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_ID", request.SubscriberId);
                        cmd.Parameters.AddWithValue("@UPDATE_USER", request.UpdateUser);

                        var ReturnParameter = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                        ReturnParameter.Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(ReturnParameter.Value) == 0 ? false : true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return result;
        }

        public static List<SubscriberTypeResponse> GetAllSubscriberType()
        {
            List<SubscriberTypeResponse> response = new List<SubscriberTypeResponse>();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_ALL_SUBSCRIBER_TYPE, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            SubscriberTypeResponse item = new SubscriberTypeResponse();
                            item.SubscriberTypeId = Convert.ToInt32(table.Rows[i]["SUBSCRIBER_TYPE_ID"]);
                            item.TypeName = table.Rows[i]["TYPE_NAME"].ToString();
                            response.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static List<SubscriptionResponse> GetAllSubscription()
        {
            List<SubscriptionResponse> response = new List<SubscriptionResponse>();

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_ALL_SUBSCRIPTION, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            SubscriptionResponse item = new SubscriptionResponse();
                            item.SubscriptionId = Convert.ToInt32(table.Rows[i]["SUBSCRIPTION_ID"]);
                            item.SubscriptionType = table.Rows[i]["SUBSCRIPTION_TYPE"].ToString();
                            item.FinalPaymentDay = table.Rows[i]["FINAL_PAYMENT_DAY"].ToString();
                            item.Deposit = Convert.ToInt32(table.Rows[i]["DEPOSIT"]);
                            item.InsertUser = table.Rows[i]["INSERT_USER"].ToString();
                            item.InsertDate = Convert.ToDateTime(table.Rows[i]["INSERT_DATE"].ToString());
                            item.UpdateUser = table.Rows[i]["UPDATE_USER"].ToString();
                            if (!String.IsNullOrEmpty(table.Rows[i]["UPDATE_DATE"].ToString()))
                                item.UpdateDate = Convert.ToDateTime(table.Rows[i]["UPDATE_DATE"].ToString());
                            response.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return response;
        }

        public static int GetInvoiceAllUnpaidTotalAmount(int SubscriberId)
        {
            int InvoiceAllUnpaidTotalAmount = 0;

            using (SqlConnection con = new SqlConnection(Variables.PaymentSystemDBConnection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLConstants.SP_GET_INVOICE_ALL_UNPAID_TOTAL_AMOUNT, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SUBSCRIBER_ID", SubscriberId);

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if(table.Rows.Count > 0)
                        {
                            if (table.Rows[0]["TOTAL_AMOUNT"].ToString().Trim().Equals(""))
                                InvoiceAllUnpaidTotalAmount = 0;
                            else
                                InvoiceAllUnpaidTotalAmount = Convert.ToInt32(table.Rows[0]["TOTAL_AMOUNT"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return InvoiceAllUnpaidTotalAmount;
        }
    }
}