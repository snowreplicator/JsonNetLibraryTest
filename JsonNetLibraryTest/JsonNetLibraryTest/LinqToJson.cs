using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JsonNetLibraryTest;

public class LinqToJson
{
    public static void Test2()
    {
        Console.WriteLine("\nTest2 - linq to json:");

        JObject jObject = JObject.Parse(
            @"{
                'CPU': 'Intel',
                'Drives': [
                    'DVD read/writer',
                    '500 gigabyte hard drive'
                ]
            }");

        string cpu = (string)jObject["CPU"];
        Console.WriteLine($"cpu: {cpu}");

        string firstDrive = (string)jObject["Drives"]![0];
        Console.WriteLine($"firstDrive: {firstDrive}");

        IList<string> allDrives = jObject["Drives"].Select(jToken => (string)jToken).ToList();
        Console.WriteLine($"allDrives: {string.Join(", ", allDrives)}");
    }

    public static void Test3()
    {
        Console.WriteLine("\nTest3 - linq to json:");

        string json = @"{
                    'channel': {
                        'title': 'James Newton-King',
                        'link': 'http://james.newtonking.com',
                        'description': 'James Newton-King\'s blog.',
                        'item': [
                            {
                                'title': 'Json.NET 1.3 + New license + Now on CodePlex',
                                'description': 'Announcing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                                'link': 'http://james.newtonking.com/projects/json-net.aspx',
                                'categories': [
                                    'Json.NET',
                                    'CodePlex'
                                ]
                            },
                            {
                                'title': 'LINQ to JSON beta',
                                'description': 'Announcing LINQ to JSON',
                                'link': 'http://james.newtonking.com/projects/json-net.aspx',
                                'categories': [
                                    'Json.NET',
                                    'LINQ'
                                ]
                            }
                        ]
                    }
                }";

        JObject rss = JObject.Parse(json);

        string rssTitle = (string)rss["channel"]!["title"];
        Console.WriteLine($"rssTitle: {rssTitle}");

        string itemTitle = (string)rss["channel"]["item"]![0]!["title"];
        Console.WriteLine($"itemTitle: {itemTitle}");

        JArray categories = (JArray)rss["channel"]["item"][0]["categories"];
        Console.WriteLine($"categories: {categories}");

        IList<string> categoriesText = categories!.Select(jToken => (string)jToken).ToList();
        Console.WriteLine($"categoriesText: {string.Join(", ", categoriesText)}");
    }
}