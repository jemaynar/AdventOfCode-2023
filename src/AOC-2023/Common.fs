module Common
    open System.IO

    // Return array of strings the binary input.
    let getData (filename) =
        File.ReadLines(filename)