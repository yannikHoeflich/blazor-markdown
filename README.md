<p style="text-align: center;">

# Blazor Markdown

![.NET Core](https://github.com/georgemathieson/blazor-markdown/workflows/.NET%20Core/badge.svg) ![Nuget](https://img.shields.io/nuget/v/BlazorMarkdown?style=flat-square) ![Nuget](https://img.shields.io/nuget/dt/BlazorMarkdown?style=flat-square)

A [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) Markdown component that enables you to include Markdown files in your server-side Blazor apps.

</p>

## Why?

Static content in Blazor means writing HTML. Yikes! Markdown source files are easier to read, write, and update when compared to HTML. Sounds good eh? 

No longer will  `<pre><code>` content be weirdly indented or heavily escaped. Gone are the days of misusing the `<br>` tag.

## Get started

Install the [NuGet package](https://www.nuget.org/packages/BlazorMarkdown/) into your server side Blazor project.

```powershell
PM> Install-Package BlazorMarkdown
```

```
$ dotnet add package BlazorMarkdown
```

Add the following to your `_Imports.razor`
```
@using BlazorMarkdown
```

## Usage

### Markdown file
The `MarkdownFile` component takes the path to a Markdown file in the `FilePath` parameter. The component will convert the Markdown file to HTML in place of the component.

```html
<MarkdownFile FilePath="wwwroot/markdown-file.md" />
```
> **Tip:** :bulb:
> If you put your Markdown files outside of the wwwroot folder then you need to ensure they are copied to the output directory (select properties on the file from within Visual Studio).

### MarkdownString
The `MarkdownString` component takes a raw markdown string with the `Markdown` parameter and converts it into HTML that is placed inside the component.

```html
<MarkdownString Markdown='@MarkdownString'>

@code{
    string MarkdownString = "# Headline"
}
```

## Additional options
Blazor Markdown uses [Markdig](https://github.com/lunet-io/markdig) under the hood. Markdig has different [extensions](https://github.com/lunet-io/markdig/blob/master/src/Markdig/MarkdownExtensions.cs) that you can configure. For this reason the Pipeline property is overridable on the Markdown component.

```csharp
public class MyCustomComponent : Markdown
{
    public override MarkdownPipeline Pipeline => new MarkdownPipelineBuilder()
        // Your chosen extensions here.
        .Build();
}
```
```html
<MyCustomComponent FilePath="wwwroot/markdown-file.md" />
```
By default, Blazor Markdown uses all extensions except the BootStrap,  SmartyPants and soft line as hard line breaks extensions.
