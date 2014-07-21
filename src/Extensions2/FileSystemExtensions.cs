using System;
using System.IO;
using System.Linq;

public static class FileSystemExtensions
{
    public static string ToNearestProjectFolder(this string path)
    {
        var separator = Path.DirectorySeparatorChar;
        var pieces = path.Split(separator).Count();
        return string.Join(separator.ToString(), path.Split(separator).Take(pieces - 2));
    }

    public static string ToNearestSolutionFolder(this string path)
    {
        var separator = Path.DirectorySeparatorChar;
        var pieces = path.Split(separator).Count();
        return string.Join(separator.ToString(), path.Split(separator).Take(pieces - 4));
    }

    public static string GoUp(this string path, int times)
    {
        var separator = Path.DirectorySeparatorChar;
        return string.Join(separator, path.Split(new [] { separator }).Reverse().Skip(times).Reverse());
    }
}