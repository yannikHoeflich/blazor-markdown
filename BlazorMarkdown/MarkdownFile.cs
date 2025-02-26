﻿using System.IO;

using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorMarkdown {
    /// <summary>
    /// A Component for displaying Markdown.
    /// </summary>
    public class MarkdownFile : ComponentBase {
        /// <summary>
        /// Gets or sets the path to the Markdown file.
        /// </summary>
        [Parameter]
        public string FilePath { get; set; }

        private MarkupString _markupString = new MarkupString();

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
            builder.AddContent(0, _markupString);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet() {
            base.OnParametersSet();
            var markdown = File.ReadAllText(FilePath);
            _markupString = new MarkupString(Markdown.ToHtml(markdown, Pipeline));
        }
    }
}
