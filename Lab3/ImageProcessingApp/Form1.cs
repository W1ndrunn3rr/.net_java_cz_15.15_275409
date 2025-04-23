namespace ImageProcessingApp;

using System.Drawing;

public static class Operations
{
    public static Bitmap Negative(Bitmap image)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                Color negative = Color.FromArgb(
                    255 - pixel.R,
                    255 - pixel.G,
                    255 - pixel.B);
                result.SetPixel(i, j, negative);
            }
        }
        return result;
    }
    
    public static Bitmap Gray(Bitmap image, float factor)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                
                int avg = (pixel.R + pixel.G + pixel.B) / 3;

                int r = avg;
                int g = avg;
                int b = avg;
                
                result.SetPixel(i, j, Color.FromArgb(r, g, b));
            }
        }
        return result;
    }
    
    public static Bitmap Threshold(Bitmap image, int threshold)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                int grayValue = (pixel.R + pixel.G + pixel.B) / 3;
                Color newColor = grayValue > threshold ? Color.White : Color.Black;
                result.SetPixel(i, j, newColor);
            }
        }
        return result;
    }
    
    public static Bitmap ToRed(Bitmap image)
    {
        Bitmap result = new Bitmap(image.Width, image.Height);
        
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                result.SetPixel(i, j, Color.FromArgb(pixel.R, 0, 0));
            }
        }
        return result;
    }
    
}

public partial class Form1 : Form
{
    private Bitmap? image;
    public Form1()
    {
        InitializeComponent();
    }

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        var file = openFileDialog1.FileName;
        
        image = new Bitmap(file);
        pictureBoxOrg.Image = image;
        pictureBoxOrg.SizeMode = PictureBoxSizeMode.StretchImage;
        
    }

    private void buttonProcessImage_Click(object sender, EventArgs e)
    {
        ParallelOptions opt = new ParallelOptions { MaxDegreeOfParallelism = 4 };
        int[] threadsUsed = new int[Environment.ProcessorCount];
        
        Bitmap[] sourceImages = new Bitmap[4];
        Bitmap[] results = new Bitmap[4];
    
        for (int i = 0; i < 4; i++)
        {
            sourceImages[i] = new Bitmap(image!); 
            results[i] = new Bitmap(sourceImages[i].Width, sourceImages[i].Height);
        }


        Parallel.Invoke(opt,
            () => results[0] = Operations.Negative(sourceImages[0]),
            () => results[1] = Operations.Gray(sourceImages[1], 2.0f),
            () => results[2] = Operations.Threshold(sourceImages[2], 128),
            () => results[3] = Operations.ToRed(sourceImages[3])
        );

        pictureBoxNeg.Image = results[0];
        pictureBoxNeg.SizeMode = PictureBoxSizeMode.StretchImage;
        
        pictureBoxProg.Image = results[1];
        pictureBoxProg.SizeMode = PictureBoxSizeMode.StretchImage;
        
        pictureBoxGray.Image = results[2];
        pictureBoxGray.SizeMode = PictureBoxSizeMode.StretchImage;
        
        pictureBoxRed.Image = results[3];
        pictureBoxRed.SizeMode = PictureBoxSizeMode.StretchImage;
    }
}