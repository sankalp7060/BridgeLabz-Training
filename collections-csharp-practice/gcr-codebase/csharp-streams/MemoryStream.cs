using System;
using System.IO;

class MemoryStream
{
    static void Main()
    {
        string inputImage = "image.jpg";
        string outputImage = "copy_image.jpg";

        try
        {
            // Read the original image into a byte array
            byte[] imageBytes = File.ReadAllBytes(inputImage);

            // Use the real MemoryStream from System.IO
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
            {
                File.WriteAllBytes(outputImage, ms.ToArray());
            }

            Console.WriteLine("Image copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
    }
}
