using SixLabors.Fonts.Tables.AdvancedTypographic;
using System.Collections.Generic;

namespace FontInspector
{
    public static class FeatureTagMeta
    {
        private static Dictionary<FeatureTags, string> lookupName = new Dictionary<FeatureTags, string>();

        public static string GetName(FeatureTags c)
        {
            if (lookupName.TryGetValue(c, out var name))
            {
                return name;
            }

            return string.Empty;
        }
        static FeatureTagMeta()
        {
            lookupName.Add(FeatureTags.AccessAllAlternates, "Access All Alternates");


            lookupName.Add(FeatureTags.AboveBaseForms, "Above-base Forms");


            lookupName.Add(FeatureTags.AboveBaseMarkPositioning, "Above-base Mark Positioning");

            lookupName.Add(FeatureTags.AboveBaseSubstitutions, "Above-base Substitutions");

            lookupName.Add(FeatureTags.AlternativeFractions, "Alternative Fractions");

            lookupName.Add(FeatureTags.Akhand, "Akhand");

            lookupName.Add(FeatureTags.BelowBaseForms, "Below-base Forms");
            lookupName.Add(FeatureTags.BelowBaseMarkPositioning, "Below-base Mark Positioning");

            lookupName.Add(FeatureTags.BelowBaseSubstitutions, "Below-base Substitutions");

            lookupName.Add(FeatureTags.ContextualAlternates, "Contextual Alternates");

            lookupName.Add(FeatureTags.CaseSensitiveForms, "Case-Sensitive Forms");

            lookupName.Add(FeatureTags.GlyphCompositionDecomposition, "Glyph Composition/Decomposition");

            lookupName.Add(FeatureTags.ConjunctFormAfterRo, "Conjunct Form After Ro");

            lookupName.Add(FeatureTags.ConjunctForms, "Conjunct Forms");

            lookupName.Add(FeatureTags.ContextualLigatures, "Contextual Ligatures");

            lookupName.Add(FeatureTags.CenteredCjkPunctuation, "Centered CJK Punctuation");

            lookupName.Add(FeatureTags.CapitalSpacing, "Capital Spacing");

            lookupName.Add(FeatureTags.ContextualSwash, "Contextual Swash");

            lookupName.Add(FeatureTags.CursivePositioning, "Cursive Positioning");

            lookupName.Add(FeatureTags.PetiteCapitalsFromCapitals, "Petite Capitals From Capitals");

            lookupName.Add(FeatureTags.SmallCapitalsFromCapitals, "Small Capitals From Capitals");

            lookupName.Add(FeatureTags.Distances, "Distances");

            lookupName.Add(FeatureTags.DiscretionaryLigatures, "Discretionary Ligatures");

            lookupName.Add(FeatureTags.Denominators, "Denominators");

            lookupName.Add(FeatureTags.DotlessForms, "Dotless Forms");

            lookupName.Add(FeatureTags.ExpertForms, "Expert Forms");

            lookupName.Add(FeatureTags.FinalGlyphOnLineAlternates, "Final Glyph on Line Alternates");

            lookupName.Add(FeatureTags.TerminalForm2, "Terminal Form #2");
            lookupName.Add(FeatureTags.TerminalForm3, "Terminal Form #3");

            lookupName.Add(FeatureTags.TerminalForms, "Terminal Forms");

            lookupName.Add(FeatureTags.FlattenedAscentForms, "Flattened ascent forms");

            lookupName.Add(FeatureTags.Fractions, "Fractions");

            lookupName.Add(FeatureTags.FullWidths, "Full Widths");

            lookupName.Add(FeatureTags.HalfForms, "Half Forms");

            lookupName.Add(FeatureTags.HalantForms, "Halant Forms");

            lookupName.Add(FeatureTags.AlternateHalfWidths, "Alternate Half Widths");

            lookupName.Add(FeatureTags.HistoricalForms, "Historical Forms");

            lookupName.Add(FeatureTags.HorizontalKanaAlternates, "Horizontal Kana Alternates");

            lookupName.Add(FeatureTags.HistoricalLigatures, "Historical Ligatures");

            lookupName.Add(FeatureTags.Hangul, "Hangul");

            lookupName.Add(FeatureTags.HojoKanjiForms, "Hojo Kanji Forms (JIS X 0212-1990 Kanji Forms)");

            lookupName.Add(FeatureTags.HalfWidths, "Half Widths");

            lookupName.Add(FeatureTags.InitialForms, "Initial Forms");

            lookupName.Add(FeatureTags.IsolatedForms, "Isolated Forms");

            lookupName.Add(FeatureTags.Italics, "Italics");

            lookupName.Add(FeatureTags.JustificationAlternates, "Justification Alternates");

            lookupName.Add(FeatureTags.Jis78Forms, "JIS78 Forms");

            lookupName.Add(FeatureTags.Jis83Forms, "JIS83 Forms");

            lookupName.Add(FeatureTags.Jis90Forms, "JIS90 Forms");

            lookupName.Add(FeatureTags.Jis2004, "JIS2004 Forms");

            lookupName.Add(FeatureTags.Kerning, "Kerning");

            lookupName.Add(FeatureTags.LeftBounds, "Left Bounds");

            lookupName.Add(FeatureTags.Ligatures, "Standard Ligatures");

            lookupName.Add(FeatureTags.LeadingJamoForms, "Leading Jamo Forms");

            lookupName.Add(FeatureTags.LiningFigures, "Lining Figures");

            lookupName.Add(FeatureTags.LocalizedForms, "Localized Forms");

            lookupName.Add(FeatureTags.LeftToRightGlyphAlternates, "Left-to-right glyph alternates");

            lookupName.Add(FeatureTags.LeftToRightMirroredForms, "Left-to-right mirrored forms");

            lookupName.Add(FeatureTags.MarkPositioning, "Mark Positioning");

            lookupName.Add(FeatureTags.MedialForms2, "Medial Forms #2");

            lookupName.Add(FeatureTags.MedialForms, "Medial Forms");

            lookupName.Add(FeatureTags.MathematicalGreek, "Mathematical Greek");

            lookupName.Add(FeatureTags.MarkToMarkPositioning, "Mark to Mark Positioning");

            lookupName.Add(FeatureTags.Mset, "Mset");

            lookupName.Add(FeatureTags.AlternateAnnotationForms, "Alternate Annotation Forms");

            lookupName.Add(FeatureTags.NlcKanjiForms, "NLC Kanji Forms");

            lookupName.Add(FeatureTags.NuktaForms, "Nukta Forms");

            lookupName.Add(FeatureTags.Numerators, "Numerators");

            lookupName.Add(FeatureTags.OldstyleFigures, "Oldstyle Figures");

            lookupName.Add(FeatureTags.OpticalBounds, "Optical Bounds");

            lookupName.Add(FeatureTags.Ordinals, "Ordinals");

            lookupName.Add(FeatureTags.Ornaments, "Ornaments");

            lookupName.Add(FeatureTags.ProportionalAlternateWidths, "Proportional Alternate Widths");

            lookupName.Add(FeatureTags.PetiteCapitals, "Petite Capitals");

            lookupName.Add(FeatureTags.ProportionalKana, "Proportional Kana");

            lookupName.Add(FeatureTags.ProportionalFigures, "Proportional Figures");

            lookupName.Add(FeatureTags.PreBaseForms, "Pre-base Forms");

            lookupName.Add(FeatureTags.PreBaseSubstitutions, "Pre-base Substitutions");

            lookupName.Add(FeatureTags.PostBaseForms, "Post-base Forms");

            lookupName.Add(FeatureTags.PostBaseSubstitutions, "Post-base Substitutions");

            lookupName.Add(FeatureTags.ProportionalWidths, "Proportional Widths");

            lookupName.Add(FeatureTags.QuarterWidths, "Quarter Widths");

            lookupName.Add(FeatureTags.Randomize, "Randomize");

            lookupName.Add(FeatureTags.RequiredContextualAlternates, "Required Contextual Alternates");

            lookupName.Add(FeatureTags.RequiredLigatures, "Required Ligatures");

            lookupName.Add(FeatureTags.RakarForms, "Rakar Forms");

            lookupName.Add(FeatureTags.RephForm, "Reph Form");

            lookupName.Add(FeatureTags.RightBounds, "Right Bounds");

            lookupName.Add(FeatureTags.RightToLeftAlternates, "Right-to-left alternates");

            lookupName.Add(FeatureTags.RightToLeftMirroredForms, "Right-to-left mirrored forms");

            lookupName.Add(FeatureTags.RubyNotationForms, "Ruby Notation Forms");

            lookupName.Add(FeatureTags.RequiredVariationAlternates, "Required Variation Alternates");

            lookupName.Add(FeatureTags.StylisticAlternates, "Stylistic Alternates");

            lookupName.Add(FeatureTags.ScientificInferiors, "Scientific Inferiors");

            lookupName.Add(FeatureTags.OpticalSize, "Optical size");

            lookupName.Add(FeatureTags.SmallCapitals, "Small Capitals");

            lookupName.Add(FeatureTags.SimplifiedForms, "Simplified Forms");

            lookupName.Add(FeatureTags.MathScriptStyleAlternates, "Math script style alternates");

            lookupName.Add(FeatureTags.StretchingGlyphDecomposition, "Stretching Glyph Decomposition");

            lookupName.Add(FeatureTags.Subscript, "Subscript");

            lookupName.Add(FeatureTags.Superscript, "Superscript");

            lookupName.Add(FeatureTags.Swash, "Swash");

            lookupName.Add(FeatureTags.Titling, "Titling");

            lookupName.Add(FeatureTags.TrailingJamoForms, "Trailing Jamo Forms");

            lookupName.Add(FeatureTags.TraditionalNameForms, "Traditional Name Forms");

            lookupName.Add(FeatureTags.TabularFigures, "Tabular Figures");

            lookupName.Add(FeatureTags.TraditionalForms, "Traditional Forms");

            lookupName.Add(FeatureTags.ThirdWidths, "Third Widths");

            lookupName.Add(FeatureTags.Unicase, "Unicase");

            lookupName.Add(FeatureTags.AlternateVerticalMetrics, "Alternate Vertical Metrics");

            lookupName.Add(FeatureTags.VattuVariants, "Vattu Variants");

            lookupName.Add(FeatureTags.VerticalAlternates, "Vertical Alternates");

            lookupName.Add(FeatureTags.AlternateVerticalHalfMetrics, "Alternate Vertical Half Metrics");

            lookupName.Add(FeatureTags.VowelJamoForms, "Vowel Jamo Forms");

            lookupName.Add(FeatureTags.VerticalKanaAlternates, "Vertical Kana Alternates");

            lookupName.Add(FeatureTags.VerticalKerning, "Vertical Kerning");

            lookupName.Add(FeatureTags.ProportionalAlternateVerticalMetrics, "Proportional Alternate Vertical Metrics");

            lookupName.Add(FeatureTags.VerticalAlternatesAndRotation, "Vertical Alternates and Rotation");

            lookupName.Add(FeatureTags.VerticalAlternatesForRotation, "Vertical Alternates for Rotation");
            lookupName.Add(FeatureTags.SlashedZero, "Slashed Zero");
        }
    }
}
