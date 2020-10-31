using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class GetDataService
    {
        public static List<Issue> contextissues()
        {
            //var issues = new List<Issue>();
            using (var db = new Context())
            {
                var issues = (from i in db.Issue select i).ToList();
                return issues;
            }
          
        }

        public static ObservableCollection<Issue> GetIssues(string connectionString)
        {
            const string GetIssuesQuery = " SELECT * FROM Issue";

            var issues = new ObservableCollection<Issue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetIssuesQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var issue = new Issue();





                                    issue.IssueId = reader.GetInt32(0);
                                    issue.Issue1 = reader.GetString(1);
                                    issue.IssueTime = reader.GetDateTime(2);
                                    issue.CustomerId = reader.GetInt32(3);
                                    issue.CategoryId = reader.GetInt32(4);
                                    issue.SituationId = reader.GetInt32(5);
                                    if (reader.IsDBNull(6) == false)
                                        issue.PictureId = reader.GetInt32(6);
                                    if (reader.IsDBNull(7) == false)
                                        issue.CommentId = reader.GetInt32(7);

                                    issues.Add(issue);
                                }
                            }
                        }
                    }
                }
                return issues;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;

        }

        public static ObservableCollection<Issue> GetGoodIssue(string connectionString)
        {
            

            var issues = new ObservableCollection<Issue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            try
                            {
                                const string GetIssuesQuery = "Select * from Issue Inner join Customer on Issue.customer_id=Customer.customer_id " +
                                    "Inner join Category on Issue.category_id=Category.category_id Inner join Situation on Issue.situation_id=Situation.situation_id Inner join Comment on Issue.comment_id=Comment.comment_id Inner join Picture on Issue.picture_id=Picture.picture_id";
                                cmd.CommandText = GetIssuesQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var issue = new Issue();





                                        issue.IssueId = reader.GetInt32(0);
                                        issue.Issue1 = reader.GetString(1);
                                        issue.IssueTime = reader.GetDateTime(2);
                                        issue.CustomerId = reader.GetInt32(3);
                                        issue.CategoryId = reader.GetInt32(4);
                                        issue.SituationId = reader.GetInt32(5);
                                        if (reader.IsDBNull(6) == false)
                                            issue.PictureId = reader.GetInt32(6);
                                        if (reader.IsDBNull(7) == false)
                                            issue.CommentId = reader.GetInt32(7);
                                        //issue.CustomerName = reader.GetString(9);
                                        //issue.Category1 = reader.GetString(11);
                                        //issue.Situation1 = reader.GetString(13);
                                        //issue.Comment1 = reader.GetString(16);
                                        //issue.CommentTime = reader.GetDateTime(17);
                                        //issue.Picture1 = reader.GetString(20);

                                        issues.Add(issue);
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                const string GetIssuesQuery = "Select * from Issue Inner join Customer on Issue.customer_id=Customer.customer_id " +
                                        "Inner join Category on Issue.category_id=Category.category_id Inner join Situation on Issue.situation_id=Situation.situation_id Inner join Comment on Issue.comment_id=Comment.comment_id";
                                cmd.CommandText = GetIssuesQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var issue = new Issue();





                                        issue.IssueId = reader.GetInt32(0);
                                        issue.Issue1 = reader.GetString(1);
                                        issue.IssueTime = reader.GetDateTime(2);
                                        issue.CustomerId = reader.GetInt32(3);
                                        issue.CategoryId = reader.GetInt32(4);
                                        issue.SituationId = reader.GetInt32(5);
                                        if (reader.IsDBNull(6) == false)
                                            issue.PictureId = reader.GetInt32(6);
                                        if (reader.IsDBNull(7) == false)
                                            issue.CommentId = reader.GetInt32(7);
                                        //issue.CustomerName = reader.GetString(9);
                                        //issue.Category1 = reader.GetString(11);
                                        //issue.Situation1 = reader.GetString(13);
                                        //issue.Comment = reader.GetString(16);
                                        //issue.CommentTime = reader.GetDateTime(17);

                                        issues.Add(issue);
                                    }
                                }
                            }
                            catch
                            { 
                            }

                            try
                            {

                                const string GetIssuesQuery = "Select * from Issue Inner join Customer on Issue.customer_id=Customer.customer_id " +
                                    "Inner join Category on Issue.category_id=Category.category_id Inner join Situation on Issue.situation_id=Situation.situation_id";
                                cmd.CommandText = GetIssuesQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var issue = new Issue();





                                        issue.IssueId = reader.GetInt32(0);
                                        issue.Issue1 = reader.GetString(1);
                                        issue.IssueTime = reader.GetDateTime(2);
                                        issue.CustomerId = reader.GetInt32(3);
                                        issue.CategoryId = reader.GetInt32(4);
                                        issue.SituationId = reader.GetInt32(5);
                                        if (reader.IsDBNull(6) == false)
                                            issue.PictureId = reader.GetInt32(6);
                                        if (reader.IsDBNull(7) == false)
                                            issue.CommentId = reader.GetInt32(7);
                                        //issue.CustomerName = reader.GetString(9);
                                        //issue.Category1 = reader.GetString(11);
                                        //issue.Situation1 = reader.GetString(13);

                                        issues.Add(issue);
                                    }
                                }
                            }
                            catch
                            {

                            }
                           

                            
                        }
                    }
                }
                return issues;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;

        }


    }
}
