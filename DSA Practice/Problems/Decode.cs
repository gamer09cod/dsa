using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

public class Decode
{
    // It takes the Google Doc URL and prints the decoded grid.
    public static async Task PrintGridFromGoogleDoc(string url)
    {
        string html = await FetchHtml(url);

        List<GridCharacter> characters = ParseCharacters(html);

        PrintGrid(characters);
    }
    
    // Fetches HTML string data
    private static async Task<string> FetchHtml(string url)
    {
        using HttpClient client = new HttpClient();
        return await client.GetStringAsync(url);
    }
    
    //Parses HTML string data into List<GridCharacter>
    private static List<GridCharacter> ParseCharacters(string html)
    {
        var characters = new List<GridCharacter>();

        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(html);

        var rows = document.DocumentNode.SelectNodes("//table//tr");

        if (rows == null)
            return characters;

        foreach (var row in rows)
        {
            var cells = row.SelectNodes("./td");

            if (cells == null || cells.Count < 3)
                continue;

            string xText = CleanText(cells[0].InnerText);
            string character = CleanText(cells[1].InnerText);
            string yText = CleanText(cells[2].InnerText);

            if (!int.TryParse(xText, out int x))
                continue;

            if (!int.TryParse(yText, out int y))
                continue;

            characters.Add(
                new GridCharacter(x, y, character)
            );
        }

        return characters;
    }

    private static string CleanText(string text)
    {
        return HtmlEntity
            .DeEntitize(text)
            .Trim();
    }
    
    //Prints List<GridCharacter> starting maxY so that it does'nt print inverted
    private static void PrintGrid(List<GridCharacter> characters)
    {
        if (characters.Count == 0)
        {
            Console.WriteLine("No grid data found.");
            return;
        }

        var lookup = new Dictionary<(int x, int y), string>();

        int maxX = 0;
        int maxY = 0;

        foreach (var item in characters)
        {
            lookup[(item.X, item.Y)] = item.Character;

            maxX = Math.Max(maxX, item.X);
            maxY = Math.Max(maxY, item.Y);
        }

        // Print from highest Y down to 0 so the letters are upright.
        for (int y = maxY; y >= 0; y--)
        {
            for (int x = 0; x <= maxX; x++)
            {
                if (lookup.TryGetValue((x, y), out string? character))
                {
                    Console.Write(character);
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine();
        }
    }

    private record GridCharacter(
        int X,
        int Y,
        string Character
    );
    
    public static async Task Main(String[] args)
    {
        //https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub
        string url =
            "https://docs.google.com/document/d/e/2PACX-1vTMOmshQe8YvaRXi6gEPKKlsC6UpFJSMAk4mQjLm_u1gmHdVVTaeh7nBNFBRlui0sTZ-snGwZM4DBCT/pub";
        await PrintGridFromGoogleDoc(url);
    }
}