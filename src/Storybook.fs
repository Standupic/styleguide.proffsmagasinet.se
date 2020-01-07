module PM.StyleGuide.Storybook

open Fable.Core
open Fable.React

type RenderFunction = unit -> ReactElement

type [<AllowNullLiteral>] StoryDecoratorInvokeContext =
    abstract kind : string with get, set
    abstract story : string with get, set

type [<AllowNullLiteral>] DecoratorParameters =
    [<Emit "$0[$1]{{=$2}}">] abstract Item : key:string -> obj option with get, set

type [<AllowNullLiteral>] StoryDecorator =
    [<Emit "$0($1...)">] abstract Invoke : story:RenderFunction * context:StoryDecoratorInvokeContext -> ReactElement option

type [<AllowNullLiteral>] Story =
    abstract kind : string
    abstract add : storyName:string * callback:RenderFunction * ?parameters:DecoratorParameters -> Story
    abstract addDecorator : decorator:StoryDecorator -> Story
    abstract addParameters : parameters:DecoratorParameters -> Story

type [<AllowNullLiteral>] IExports =
    abstract storiesOf : name:string * ``module``:obj -> Story
    
/// Access a reference to the Webpack 'module' global variable
let [<Emit("module")>] webpackModule<'T> : 'T = jsNative
//Fable.Import.JS.Glo

/// import * from '@storybook/react';
[<Import("*", from="@storybook/react")>]
let Storybook : IExports = jsNative

/// <summary>
/// Wrapper for Storybook.storiesOf that takes care binding the webpackModule parameter.

let storiesOf name = Storybook.storiesOf (name, webpackModule)

/// import centered from '@storybook/addon-centered';


