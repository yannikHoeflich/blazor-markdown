using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorMarkdown {
    /// <summary>
    /// A Component for displaying Markdown.
    /// </summary>
    public class MarkdownString : ComponentBase {
        /// <summary>
        /// Gets or sets the path to the Markdown file.
        /// </summary>
        [Parameter]
        public string Markdown { get; set; }

        private MarkupString _markupString = new();
        private int _lastHash = 0;

        /// <summary>
        /// Gets the <see cref="MarkdownPipeline"/> to use.
        /// </summary>
        public virtual MarkdownPipeline Pipeline => new MarkdownPipelineBuilder()
            .UseEmojiAndSmiley()
            .UseAdvancedExtensions()
            .Build();

        /// <inheritdoc/>
        protected override void BuildRenderTree(RenderTreeBuilder builder) {
            base.BuildRenderTree(builder);

            UpdateMarkdownIfRequired();
            builder.AddContent(0, _markupString);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet() {
            base.OnParametersSet();
            UpdateMarkdown();
        }

        private void UpdateMarkdownIfRequired() {
            if(_lastHash == Markdown.GetHashCode()) {
                return;
            }
            UpdateMarkdown();
        }

        private void UpdateMarkdown() {
            _lastHash = Markdown.GetHashCode();
            _markupString = new MarkupString(Markdig.Markdown.ToHtml(Markdown, Pipeline));
        }
    }
}
