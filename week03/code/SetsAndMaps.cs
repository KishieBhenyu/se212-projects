
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: Find pairs of reversed two-letter words.
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<int>();
        var pairs = new List<string>();

        foreach (string word in words)
        {
            char first = word[0];
            char second = word[1];

            // Ignore words with identical letters.
            if (first == second)
                continue;

            // Create numeric keys instead of allocating reversed strings.
            int key = (first << 16) | second;
            int reversedKey = (second << 16) | first;

            if (seen.Contains(reversedKey))
            {
                pairs.Add($"{second}{first} & {word}");
            }

            seen.Add(key);
        }

        return pairs.ToArray();
    }

    // Problem 2: Count the degrees in the census file.
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (string line in File.ReadLines(filename))
        {
            string[] fields = line.Split(',');

            // The degree is in the fourth column (index 3).
            if (fields.Length <= 3)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees.Add(degree, 1);
        }

        return degrees;
    }

    // Problem 3: Check whether two words are anagrams.
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLowerInvariant();
        word2 = word2.Replace(" ", "").ToLowerInvariant();

        if (word1.Length != word2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts.Add(letter, 1);
        }

        foreach (char letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
                return false;
        }

        return true;
    }

    // Problem 5: Retrieve and summarize today's earthquakes.
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        string json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        FeatureCollection? featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var earthquakes = new List<string>();

        if (featureCollection?.Features == null)
            return [];

        foreach (var feature in featureCollection.Features)
        {
            string? place = feature.Properties?.Place;
            double? magnitude = feature.Properties?.Mag;

            if (place != null && magnitude.HasValue)
            {
                earthquakes.Add($"{place} - Mag {magnitude.Value}");
            }
        }

        return earthquakes.ToArray();
    }
}
