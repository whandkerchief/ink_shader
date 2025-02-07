# Ink Drawing Effect in Unity

[![Video Showcase](./videos/Inkshader_Showcase.mp4)]

This project is a showcase of an ink drawing effect that I created on Unity, that can be applied to any 3D scene. The ink effect is created as 2 pieces of shader code applied as a full-screen render feature on the Universal Render Pipeline.

## Outline Shader

The outline shader takes the following inputs:

- `_Normal_Threshold` (float)
- `_Colour_Threshold` (float)
- `_Outline_Colour` (colour)
- `_Far_Colour` (colour)
- `_Distance_Min` (float)
- `_Distance_Max` (float)

The outline shader compares each pixel with its neighbors using matrix convolution to find the image derivative of color and normal data with respect to the pixel’s x and y coordinates. The shader compares the derivatives at the pixel coordinate with `_Normal_Threshold` and `_Colour_Threshold`, and when a significant change is detected, the pixel is labeled as an outline. Otherwise, the pixel is drawn as white.

If the object in the render buffer at the pixel has a distance from the camera that is less than `_Distance_Min`, the outline at the pixel is drawn with `_Outline_Colour`. If the distance from the camera is greater than `_Distance_Max`, the outline is drawn with `_Far_Colour`. When the distance of the object is between `_Distance_Min` and `_Distance_Max`, the pixel is drawn with a color interpolated between `_Outline_Colour` and `_Far_Colour`. This creates an outline effect with a changing color depending on the distance of the object from the camera.

## Blue Noise Shader

Taking the output from the outline shader, a blue noise texture is masked over the screen. At each pixel, the color at the position is compared with the color of the blue noise texture at that position. If the color at the pixel is darker than the color of the blue noise texture at that position, it will be rendered as black. Otherwise, it is drawn as white. This creates noise in the outline drawing, emulating a more sketch-like effect. You can adjust `_Outline_Colour` and `_Far_Colour` to manipulate the amount of noise in the outlines.

This ink effect was inspired by a media encoding lecture at university, where we studied AI object recognition through image edge detection, and the use of matrix convolution to calculate image derivatives.
