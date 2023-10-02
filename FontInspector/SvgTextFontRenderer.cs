using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using MudBlazor;
using SixLabors.Fonts;
using SixLabors.Fonts.Unicode;
using System.Data.SqlTypes;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static MudBlazor.Icons.Custom;


namespace FontInspector
{
    public class SvgTextFontRenderer : IColorGlyphRenderer
    {
        private StringBuilder svgString = new StringBuilder();
        private StringBuilder linesString = new StringBuilder();
        private GlyphColor? _color = null;
        public string Svg
            => $"<svg style=\"width:{boxWidth}px; height:{boxHeight}px\" viewBox=\"{-Padding} {-Padding} {maxWidth + Padding} {maxHeight + Padding}\"><g>{linesString}{svgString}</g></svg>";

        private readonly TextOptions options;
        private float fontSize => options.Font.Size;

        /// <remarks>
        ///  only really works in single glyphs situations, don't enable this when rendering larger text strings
        /// </remarks>
        public bool AddMetricAddornments { get; set; } = false;
        public float Padding { get; set; } = 20;

        public SvgTextFontRenderer(TextOptions options)
        {
            this.options = options;
        }

        public float boxWidth = -1;
        public float maxHeight = -1;
        public float maxWidth = -1;
        public float boxHeight = -1;
        public float boxRight = -1;
        public float boxBottom = -1;
        public void BeginText(in FontRectangle bounds)
        {
            svgString.Clear();
            linesString.Clear();
            //float maxGlyphWidth = FontScaleToPixelScape(options.Font.FontMetrics.UnitsPerEm);
            float maxGlyphWidth = 0;// FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.AdvanceWidthMax);
            float maxGlyphHeight = FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.AdvanceHeightMax);

            maxWidth = MathF.Max(maxGlyphWidth, bounds.Width);
            maxHeight = MathF.Max(maxGlyphHeight, bounds.Height);
            boxWidth = maxWidth + Padding * 2;
            boxHeight = maxHeight + Padding * 3;
            boxRight = maxWidth + Padding;
            boxBottom = maxHeight + Padding;
        }

        List<GlyphMetrics> metricsToAdorn = new List<GlyphMetrics>();
        public void EndText()
        {
            var metrics = metricsToAdorn.Select(glyph =>
            {
                var lsb = FontScaleToPixelScape(glyph.LeftSideBearing);
                var width = FontScaleToPixelScape(glyph.AdvanceWidth);
                var height = FontScaleToPixelScape(glyph.AdvanceHeight);
                var asscender = height - FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.Ascender);
                var baseline = height + FontScaleToPixelScape(options.Font.FontMetrics.HorizontalMetrics.Descender);
                return (lsb, width, height, asscender, baseline);
            }).Take(1);

            var lsb = metrics.Min(x => x.lsb);
            var rsb = lsb + metrics.Max(x => x.width);
            var height = metrics.Max(x => x.height);
            var asscender = metrics.Min(x => x.asscender);
            var baseline = metrics.Max(x => x.baseline);

            if (AddMetricAddornments)
            {
                AddVLine(lsb, "lsb");
                AddVLine(rsb, "advance-width");

                AddHLine(height, "descender");
                AddHLine(baseline, "baseline");
                AddHLine(asscender, "assender");
            }

            boxWidth = MathF.Max(boxWidth, rsb + Padding * 2);
            maxWidth = MathF.Max(maxWidth, rsb + Padding);
        }

        public void BeginFigure()
        {
        }

        public void EndFigure()
        {
            svgString.Append("z ");
        }

        public void AddHLine(float y, string className)
        {
            linesString.Append($"<line x1=\"{-Padding}\" y1=\"{y}\" x2=\"{boxRight}\" y2=\"{y}\" class='adornment adornment-{className}' />");
        }

        public void AddVLine(float x, string className)
        {
            linesString.Append($"<line x1=\"{x}\" y1=\"{-Padding}\" x2=\"{x}\" y2=\"{boxBottom}\" class='adornment adornment-{className}' />");
        }

        private float FontScaleToPixelScape(float fontScale)
        {
            return fontScale * (fontSize * 72) / (options.Font.FontMetrics.ScaleFactor);
        }

        public bool BeginGlyph(in FontRectangle bounds, in GlyphRendererParameters parameters)
        {

            if (options.Font.FontMetrics.TryGetGlyphMetrics(parameters.CodePoint,
                parameters.TextRun?.TextAttributes ?? default,
                parameters.TextRun?.TextDecorations ?? default,
                options.LayoutMode,
                ColorFontSupport.MicrosoftColrFormat,
                out var glyphs))
            {
                var gid = parameters.GlyphId;
                var glyph = glyphs.FirstOrDefault(x => x.GlyphId == gid);
                if (glyph != null)
                {
                    metricsToAdorn.Add(glyph);
                }
            }
            _color = null;

            svgString.Append($"<path d=\"");
            return true;
        }

        public void EndGlyph()
        {
            svgString.Append($"\" style=\"");

            //inject other styles here!!!
            if (_color != null)
            {
                svgString.Append($"fill:#{_color.Value.Red:X2}{_color.Value.Green:X2}{_color.Value.Blue:X2}{_color.Value.Alpha:X2}; ");
            }

            svgString.Append($"fill-rule: evenodd;\"");

            svgString.Append($" />");

        }

        public void CubicBezierTo(Vector2 secondControlPoint, Vector2 thirdControlPoint, Vector2 point)
        {
            svgString.Append($"C {secondControlPoint.X},{secondControlPoint.Y} {thirdControlPoint.X},{thirdControlPoint.Y} {point.X},{point.Y}");
        }

        public TextDecorations EnabledDecorations()
        {
            return TextDecorations.None;
        }
        public void LineTo(Vector2 point)
        {
            svgString.Append($"L {point.X},{point.Y}");
        }

        public void MoveTo(Vector2 point)
        {
            svgString.Append($"M {point.X},{point.Y}");
        }

        public void QuadraticBezierTo(Vector2 secondControlPoint, Vector2 point)
        {
            svgString.Append($"Q {secondControlPoint.X},{secondControlPoint.Y} {point.X},{point.Y}");
        }

        public void SetColor(GlyphColor color)
        {
            _color = color;
        }

        public void SetDecoration(TextDecorations textDecorations, Vector2 start, Vector2 end, float thickness)
        {
        }
    }
}
