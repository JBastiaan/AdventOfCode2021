// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using System.Linq;

string[] lines = System.IO.File.ReadAllLines("input.txt");

var inputs = lines.Select(l =>
{
    var parts = l.Split(' ');
    return (Command: parts[0], Value: int.Parse(parts[1]));
});

int hPos = 0;
int vPos = 0;
int aim = 0;
foreach (var input in inputs)
{
    switch (input.Command)
    {
        case "forward":
            hPos += input.Value;
            vPos += aim * input.Value;
            continue;
        case "up":
            aim -= input.Value;
            continue;
        case "down":
            aim += input.Value;
            continue;
    }
}

var answer = hPos * vPos;
Console.WriteLine(answer);


