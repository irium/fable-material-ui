[<AutoOpen>]
module rec Fable.MaterialUI
open System
open Fable.Core

[<AutoOpen>]
module Themes =
    open Fable.Core
    open Fable.Import.React
    open Fable.Helpers.React.Props

    type IPaletteIntention =
        abstract member light: string
        abstract member main: string
        abstract member dark: string
        abstract member contrastText: string

    type [<StringEnum; RequireQualifiedAccess>] PaletteType = Dark | Light

    type IPaletteCommon =
        abstract member black: string
        abstract member white: string

    type IPaletteAction =
        abstract member active: string
        abstract member hover: string
        abstract member hoverOpacity: float
        abstract member selected: string
        abstract member disabled: string
        abstract member disabledBackground: string

    type IPaletteBackground =
        abstract member paper: string
        abstract member ``default``: string

    type IPaletteText =
        abstract member primary: string
        abstract member secondary: string
        abstract member disabled: string
        abstract member hint: string

    type IColor =
        abstract member ``50``: string
        abstract member ``100``: string
        abstract member ``200``: string
        abstract member ``300``: string
        abstract member ``400``: string
        abstract member ``500``: string
        abstract member ``600``: string
        abstract member ``700``: string
        abstract member ``800``: string
        abstract member ``900``: string
        abstract member A100: string
        abstract member A200: string
        abstract member A400: string
        abstract member A700: string

    type IPalette =
        abstract member common: IPaletteCommon
        abstract member ``type``: PaletteType
        abstract member primary: IPaletteIntention
        abstract member secondary: IPaletteIntention
        abstract member error: IPaletteIntention
        abstract member grey: IColor
        abstract member contrastThreshold: int
        abstract getContrastText: background: string -> string
        abstract augmentColor: color: IPaletteIntention * mainShade : U2<int, string> * lightShade : U2<int, string> * darkShade : U2<int, string> -> unit
        abstract member tonalOffset: float
        abstract member text: IPaletteText
        abstract member divider: string
        abstract member background: IPaletteBackground
        abstract member action: IPaletteAction

    type [<StringEnum; RequireQualifiedAccess>] TextDirection = Ltr | Rtl

    type IShape =
        abstract member borderRadius: int

    type ISpacing =
        abstract member ``unit``: int

    type IZIndex =
        abstract member mobileStepper: int
        abstract member appBar: int
        abstract member drawer: int
        abstract member modal: int
        abstract member snackbar: int
        abstract member tooltip: int

    type ITypography =
        abstract member fontSize: string
        abstract member fontWeight: int
        abstract member fontFamily: string
        abstract member letterSpacing: string
        abstract member lineHeight: string
        abstract member marginLeft: string
        abstract member color: string
        abstract member textTransform: string

    type IThemeTypography =
        abstract round: px: float -> float
        abstract pxToRem: px: float -> string
        abstract member fontFamily: string
        abstract member fontSize: string
        abstract member fontWeightLight: int
        abstract member fontWeightRegular: int
        abstract member fontWeightMedium: int
        abstract member display4: ITypography
        abstract member dispaly3: ITypography
        abstract member display2: ITypography
        abstract member display1: ITypography
        abstract member headline: ITypography
        abstract member title: ITypography
        abstract member subheading: ITypography
        abstract member body2: ITypography
        abstract member body1: ITypography
        abstract member caption: ITypography
        abstract member button: ITypography

    type IBreakpointValues =
        abstract member xs: int
        abstract member sm: int
        abstract member md: int
        abstract member lg: int
        abstract member xl: int

    type IBreakpoints =
        abstract member keys: Props.MaterialSize list
        abstract member values: IBreakpointValues
        abstract up: key: U2<Props.MaterialSize, int> -> string
        abstract down: key: U2<Props.MaterialSize, int> -> string
        abstract only: key: Props.MaterialSize -> string
        abstract between: start: Props.MaterialSize * ``end``: Props.MaterialSize -> string
        abstract width: key: Props.MaterialSize -> int

    type IMixins =
        abstract gutters: ?styles : CSSProperties -> CSSProperties
        abstract toolbar: CSSProperties

    type IEasing =
        abstract member easeInOut: string
        abstract member easeOut: string
        abstract member easeIn: string
        abstract member sharp: string

    type IDuration =
        abstract member shortest: float
        abstract member shorter: float
        abstract member short: float
        abstract member standard: float
        abstract member complex: float
        abstract member enteringScreen: float
        abstract member leavingScreen: float

    type ITransitionOptions =
        abstract member duration: U2<float, string> with get,set
        abstract member easing: string with get,set
        abstract member delay: U2<float, string> with get,set

    type ITransitions =
        abstract member easing: IEasing
        abstract member duration: IDuration
        abstract create: props : U2<string, string list> * ?options: ITransitionOptions -> string
        abstract getAutoHeightDuration: height : int -> int

    type ITheme =
        abstract member breakpoints: IBreakpoints
        abstract member direction: TextDirection
        abstract member overrides: obj
        abstract member palette: IPalette
        abstract member props: obj
        abstract member shadows: string list
        abstract member typography: IThemeTypography
        abstract member shape: IShape
        abstract member spacing: ISpacing
        abstract member zIndex: IZIndex
        abstract member mixins: IMixins
        abstract member transitions: ITransitions

    type IStyles = interface end

    type Styles =
        | [<Erase>] Custom' of string * obj
        interface IStyles

    module Styles =
        open Fable.Core.JsInterop

        let Custom (key, (props : CSSProp list)) =
            Styles.Custom' (key, props |> keyValueList CaseRules.LowerFirst)

        let inline AdornedStart props = Custom ("adornedStart", props)
        let inline AdornedEnd props = Custom ("adornedEnd", props)
        let inline NotchedOutline props = Custom ("notchedOutline", props)
        let inline InputAdornedStart props = Custom ("inputAdornedStart", props)
        let inline InputAdornedEnd props = Custom ("inputAdornedEnd", props)
        let inline Absolute props = Custom ("absolute", props)
        let inline Action props = Custom ("action", props)
        let inline ActionIcon props = Custom ("actionIcon", props)
        let inline ActionIconActionPosLeft props = Custom ("actionIconActionPosLeft", props)
        let inline Actions props = Custom ("actions", props)
        let inline AlignCenter props = Custom ("alignCenter", props)
        let inline AlignJistify props = Custom ("alignJistify", props)
        let inline AlignLeft props = Custom ("alignLeft", props)
        let inline AlignRight props = Custom ("alignRight", props)
        let inline AlternativeLabel props = Custom ("alternativeLabel", props)
        let inline AnchorOriginBottomCenter props = Custom ("anchorOriginBottomCenter", props)
        let inline AnchorOriginBottomLeft props = Custom ("anchorOriginBottomLeft", props)
        let inline AnchorOriginBottomRight props = Custom ("anchorOriginBottomRight", props)
        let inline AnchorOriginTopCenter props = Custom ("anchorOriginTopCenter", props)
        let inline AnchorOriginTopLeft props = Custom ("anchorOriginTopLeft", props)
        let inline AnchorOriginTopRight props = Custom ("anchorOriginTopRight", props)
        let inline Animated props = Custom ("animated", props)
        let inline Asterisk props = Custom ("asterisk", props)
        let inline Avatar props = Custom ("avatar", props)
        let inline AvatarChildren props = Custom ("avatarChildren", props)
        let inline Badge props = Custom ("badge", props)
        let inline Bar props = Custom ("bar", props)
        let inline Bar1Buffer props = Custom ("bar1Buffer", props)
        let inline Bar1Determinate props = Custom ("bar1Determinate", props)
        let inline Bar1Indeterminate props = Custom ("bar1Indeterminate", props)
        let inline Bar2Buffer props = Custom ("bar2Buffer", props)
        let inline Bar2Determinate props = Custom ("bar2Determinate", props)
        let inline Bar2Indeterminate props = Custom ("bar2Indeterminate", props)
        let inline BarColorPrimary props = Custom ("barColorPrimary", props)
        let inline BarColorSecondary props = Custom ("barColorSecondary", props)
        let inline Body props = Custom ("body", props)
        let inline Body1 props = Custom ("body1", props)
        let inline Body2 props = Custom ("body2", props)
        let inline Button props = Custom ("button", props)
        let inline Caption props = Custom ("caption", props)
        let inline Centered props = Custom ("centered", props)
        let inline Checked props = Custom ("checked", props)
        let inline Child props = Custom ("child", props)
        let inline ChildLeaving props = Custom ("childLeaving", props)
        let inline ChildPulsate props = Custom ("childPulsate", props)
        let inline Circle props = Custom ("circle", props)
        let inline CircleIndeterminate props = Custom ("circleIndeterminate", props)
        let inline CircleStatic props = Custom ("circleStatic", props)
        let inline Clickable props = Custom ("clickable", props)
        let inline ColorAction props = Custom ("colorAction", props)
        let inline ColorDefault props = Custom ("colorDefault", props)
        let inline ColorDisabled props = Custom ("colorDisabled", props)
        let inline ColorError props = Custom ("colorError", props)
        let inline ColorInherit props = Custom ("colorInherit", props)
        let inline ColorPrimary props = Custom ("colorPrimary", props)
        let inline ColorSecondary props = Custom ("colorSecondary", props)
        let inline ColorTextPrimary props = Custom ("colorTextPrimary", props)
        let inline ColorTextSecondary props = Custom ("colorTextSecondary", props)
        let inline Complet inlineed props = Custom ("complet inlineed", props)
        let inline Contained props = Custom ("contained", props)
        let inline ContainedPrimary props = Custom ("containedPrimary", props)
        let inline ContainedSecondary props = Custom ("containedSecondary", props)
        let inline Container props = Custom ("container", props)
        let inline Content props = Custom ("content", props)
        let inline Default props = Custom ("default", props)
        let inline Delete props = Custom ("deletable", props)
        let inline DeleteIcon props = Custom ("deleteIcon", props)
        let inline Dense props = Custom ("dense", props)
        let inline Disabled props = Custom ("disabled", props)
        let inline Display1 props = Custom ("display1", props)
        let inline Display2 props = Custom ("display2", props)
        let inline Display3 props = Custom ("display3", props)
        let inline Display4 props = Custom ("display4", props)
        let inline Divider props = Custom ("divider", props)
        let inline Docked props = Custom ("docked", props)
        let inline Dot props = Custom ("dot", props)
        let inline DotActive props = Custom ("dotActive", props)
        let inline Dots props = Custom ("dots", props)
        let inline Elevation0 props = Custom ("elevation0", props)
        let inline Elevation1 props = Custom ("elevation1", props)
        let inline Elevation10 props = Custom ("elevation10", props)
        let inline Elevation11 props = Custom ("elevation11", props)
        let inline Elevation12 props = Custom ("elevation12", props)
        let inline Elevation13 props = Custom ("elevation13", props)
        let inline Elevation14 props = Custom ("elevation14", props)
        let inline Elevation15 props = Custom ("elevation15", props)
        let inline Elevation16 props = Custom ("elevation16", props)
        let inline Elevation17 props = Custom ("elevation17", props)
        let inline Elevation18 props = Custom ("elevation18", props)
        let inline Elevation19 props = Custom ("elevation19", props)
        let inline Elevation2 props = Custom ("elevation2", props)
        let inline Elevation20 props = Custom ("elevation20", props)
        let inline Elevation21 props = Custom ("elevation21", props)
        let inline Elevation22 props = Custom ("elevation22", props)
        let inline Elevation23 props = Custom ("elevation23", props)
        let inline Elevation24 props = Custom ("elevation24", props)
        let inline Elevation3 props = Custom ("elevation3", props)
        let inline Elevation4 props = Custom ("elevation4", props)
        let inline Elevation5 props = Custom ("elevation5", props)
        let inline Elevation6 props = Custom ("elevation6", props)
        let inline Elevation7 props = Custom ("elevation7", props)
        let inline Elevation8 props = Custom ("elevation8", props)
        let inline Elevation9 props = Custom ("elevation9", props)
        let inline Entered props = Custom ("entered", props)
        let inline Error props = Custom ("error", props)
        let inline ExpandIcon props = Custom ("expandIcon", props)
        let inline Expanded props = Custom ("expanded", props)
        let inline ExtendedFab props = Custom ("extendedFab", props)
        let inline Fab props = Custom ("fab", props)
        let inline Filled props = Custom ("filled", props)
        let inline Fixed props = Custom ("fixed", props)
        let inline Flat props = Custom ("flat", props)
        let inline FlatPrimary props = Custom ("flatPrimary", props)
        let inline FlatSecondary props = Custom ("flatSecondary", props)
        let inline FlexContainer props = Custom ("flexContainer", props)
        let inline FocusVisible props = Custom ("focusVisible", props)
        let inline FocusHiglight props = Custom ("focusHiglight", props)
        let inline Focused props = Custom ("focused", props)
        let inline FontSizeInherit props = Custom ("fontSizeInherit", props)
        let inline Footer props = Custom ("footer", props)
        let inline Form props = Custom ("form", props)
        let inline FormControl props = Custom ("formControl", props)
        let inline FullWidth props = Custom ("fullWidth", props)
        let inline GutterBottom props = Custom ("gutterBottom", props)
        let inline Gutters props = Custom ("gutters", props)
        let inline H1 props = Custom ("h1", props)
        let inline H2 props = Custom ("h2", props)
        let inline H3 props = Custom ("h3", props)
        let inline H4 props = Custom ("h4", props)
        let inline H5 props = Custom ("h5", props)
        let inline H6 props = Custom ("h6", props)
        let inline Subtitle1 props = Custom ("subtitle1", props)
        let inline Subtitle2 props = Custom ("subtitle2", props)
        let inline Overline props = Custom ("overline", props)
        let inline SrOnly props = Custom ("srOnly", props)
        let inline Head props = Custom ("head", props)
        let inline Headline props = Custom ("headline", props)
        let inline Hidden props = Custom ("hidden", props)
        let inline Horizontal props = Custom ("horizontal", props)
        let inline Hover props = Custom ("hover", props)
        let inline Icon props = Custom ("icon", props)
        let inline IconContainer props = Custom ("iconContainer", props)
        let inline IconDirectionAsc props = Custom ("iconDirectionAsc", props)
        let inline IconDirectionDesc props = Custom ("iconDirectionDesc", props)
        let inline Img props = Custom ("img", props)
        let inline ImgFullHeight props = Custom ("imgFullHeight", props)
        let inline ImgFullWidth props = Custom ("imgFullWidth", props)
        let inline Indeterminate props = Custom ("indeterminate", props)
        let inline Indicator props = Custom ("indicator", props)
        let inline Input props = Custom ("input", props)
        let inline InputMarginDense props = Custom ("inputMarginDense", props)
        let inline InputMultiline props = Custom ("inputMultiline", props)
        let inline InputType props = Custom ("inputType", props)
        let inline InputTypeSearch props = Custom ("inputTypeSearch", props)
        let inline Inset props = Custom ("inset", props)
        let inline Invisible props = Custom ("invisible", props)
        let inline Item props = Custom ("item", props)
        let inline Label props = Custom ("label", props)
        let inline LabelContainer props = Custom ("labelContainer", props)
        let inline LabelIcon props = Custom ("labelIcon", props)
        let inline LabelPlacementStart props = Custom ("labelPlacementStart", props)
        let inline LabelWrapped props = Custom ("labelWrapped", props)
        let inline Last props = Custom ("last", props)
        let inline Layout props = Custom ("layout", props)
        let inline Light props = Custom ("light", props)
        let inline Line props = Custom ("line", props)
        let inline LineHorizontal props = Custom ("lineHorizontal", props)
        let inline LineVertical props = Custom ("lineVertical", props)
        let inline MarginDense props = Custom ("marginDense", props)
        let inline MarginNormal props = Custom ("marginNormal", props)
        let inline Media props = Custom ("media", props)
        let inline MenuItem props = Custom ("menuItem", props)
        let inline Message props = Custom ("message", props)
        let inline Mini props = Custom ("mini", props)
        let inline Modal props = Custom ("modal", props)
        let inline Multiline props = Custom ("multiline", props)
        let inline NoWrap props = Custom ("noWrap", props)
        let inline Numeric props = Custom ("numeric", props)
        let inline Outlined props = Custom ("outlined", props)
        let inline OutlinedPrimary props = Custom ("outlinedPrimary", props)
        let inline OutlinedSecondary props = Custom ("outlinedSecondary", props)
        let inline Padding props = Custom ("padding", props)
        let inline PaddingCheckbox props = Custom ("paddingCheckbox", props)
        let inline PaddingDense props = Custom ("paddingDense", props)
        let inline PaddingNone props = Custom ("paddingNone", props)
        let inline Paper props = Custom ("paper", props)
        let inline PaperAnchorBottom props = Custom ("paperAnchorBottom", props)
        let inline PaperAnchorDockedBottom props = Custom ("paperAnchorDockedBottom", props)
        let inline PaperAnchorDockedLeft props = Custom ("paperAnchorDockedLeft", props)
        let inline PaperAnchorDockedRight props = Custom ("paperAnchorDockedRight", props)
        let inline PaperAnchorDockedTop props = Custom ("paperAnchorDockedTop", props)
        let inline PaperAnchorLeft props = Custom ("paperAnchorLeft", props)
        let inline PaperAnchorRight props = Custom ("paperAnchorRight", props)
        let inline PaperAnchorTop props = Custom ("paperAnchorTop", props)
        let inline PaperFullScreen props = Custom ("paperFullScreen", props)
        let inline PaperFullWidth props = Custom ("paperFullWidth", props)
        let inline PaperScrollBody props = Custom ("paperScrollBody", props)
        let inline PaperScrollPaper props = Custom ("paperScrollPaper", props)
        let inline PaperWidthMd props = Custom ("paperWidthMd", props)
        let inline PaperWidthSm props = Custom ("paperWidthSm", props)
        let inline PaperWidthXs props = Custom ("paperWidthXs", props)
        let inline Paragraph props = Custom ("paragraph", props)
        let inline Popper props = Custom ("popper", props)
        let inline PositionAbsolute props = Custom ("positionAbsolute", props)
        let inline PositionBottom props = Custom ("positionBottom", props)
        let inline PositionEnd props = Custom ("positionEnd", props)
        let inline PositionFixed props = Custom ("positionFixed", props)
        let inline PositionStart props = Custom ("positionStart", props)
        let inline PositionStatic props = Custom ("positionStatic", props)
        let inline PositionSticky props = Custom ("positionSticky", props)
        let inline PositionTop props = Custom ("positionTop", props)
        let inline Primary props = Custom ("primary", props)
        let inline Progress props = Custom ("progress", props)
        let inline Raised props = Custom ("raised", props)
        let inline RaisedPrimary props = Custom ("raisedPrimary", props)
        let inline RaisedSecondary props = Custom ("raisedSecondary", props)
        let inline Required props = Custom ("required", props)
        let inline Regular props = Custom ("regular", props)
        let inline Ripple props = Custom ("ripple", props)
        let inline RipplePulsate props = Custom ("ripplePulsate", props)
        let inline RippleVisible props = Custom ("rippleVisible", props)
        let inline Root props = Custom ("root", props)
        let inline RootSubtitle props = Custom ("rootSubtitle", props)
        let inline Rounded props = Custom ("rounded", props)
        let inline Row props = Custom ("row", props)
        let inline ScrollButtons props = Custom ("scrollButtons", props)
        let inline ScrollButtonsAuto props = Custom ("scrollButtonsAuto", props)
        let inline Scrollable props = Custom ("scrollable", props)
        let inline Scroller props = Custom ("scroller", props)
        let inline Secondary props = Custom ("secondary", props)
        let inline SecondaryAction props = Custom ("secondaryAction", props)
        let inline Select props = Custom ("select", props)
        let inline SelectIcon props = Custom ("selectIcon", props)
        let inline SelectMenu props = Custom ("selectMenu", props)
        let inline SelectRoot props = Custom ("selectRoot", props)
        let inline Selected props = Custom ("selected", props)
        let inline Shrink props = Custom ("shrink", props)
        let inline SizeLarge props = Custom ("sizeLarge", props)
        let inline SizeSmall props = Custom ("sizeSmall", props)
        let inline Spacer props = Custom ("spacer", props)
        let inline Static props = Custom ("static", props)
        let inline Sticky props = Custom ("sticky", props)
        let inline Subheader props = Custom ("subheader", props)
        let inline Subheading props = Custom ("subheading", props)
        let inline Subtitle props = Custom ("subtitle", props)
        let inline Svg props = Custom ("svg", props)
        let inline SwitchBase props = Custom ("switchBase", props)
        let inline Text props = Custom ("text", props)
        let inline TextColorInherit props = Custom ("textColorInherit", props)
        let inline TextColorPrimary props = Custom ("textColorPrimary", props)
        let inline TextColorSecondary props = Custom ("textColorSecondary", props)
        let inline TextDense props = Custom ("textDense", props)
        let inline TextPrimary props = Custom ("textPrimary", props)
        let inline TextSecondary props = Custom ("textSecondary", props)
        let inline Tile props = Custom ("tile", props)
        let inline Title props = Custom ("title", props)
        let inline TitlePositionBottom props = Custom ("titlePositionBottom", props)
        let inline TitlePositionTop props = Custom ("titlePositionTop", props)
        let inline TitleWrap props = Custom ("titleWrap", props)
        let inline TitleWrapActionPosLeft props = Custom ("titleWrapActionPosLeft", props)
        let inline TitleWrapActionPosRight props = Custom ("titleWrapActionPosRight", props)
        let inline Toolbar props = Custom ("toolbar", props)
        let inline Tooltip props = Custom ("tooltip", props)
        let inline TooltipPlacementBottom props = Custom ("tooltipPlacementBottom", props)
        let inline TooltipPlacementLeft props = Custom ("tooltipPlacementLeft", props)
        let inline TooltipPlacementRight props = Custom ("tooltipPlacementRight", props)
        let inline TooltipPlacementTop props = Custom ("tooltipPlacementTop", props)
        let inline Touch props = Custom ("touch", props)
        let inline TouchRipple props = Custom ("touchRipple", props)
        let inline Transition props = Custom ("transition", props)
        let inline Underline props = Custom ("underline", props)
        let inline Vertical props = Custom ("vertical", props)
        let inline Wrapper props = Custom ("wrapper", props)
        let inline WrapperInner props = Custom ("wrapperInner", props)
        let inline ZeroMinWidth props = Custom ("zeroMinWidth", props)
        let inline ``Align-content-xs-center`` props = Custom ("align-content-xs-center``", props)
        let inline ``Align-content-xs-flex-end`` props = Custom ("align-content-xs-flex-end``", props)
        let inline ``Align-content-xs-flex-start`` props = Custom ("align-content-xs-flex-start``", props)
        let inline ``Align-content-xs-space-around`` props = Custom ("align-content-xs-space-around``", props)
        let inline ``Align-content-xs-space-between`` props = Custom ("align-content-xs-space-between``", props)
        let inline ``Align-items-xs-baseline`` props = Custom ("align-items-xs-baseline``", props)
        let inline ``Align-items-xs-center`` props = Custom ("align-items-xs-center``", props)
        let inline ``Align-items-xs-flex-end`` props = Custom ("align-items-xs-flex-end``", props)
        let inline ``Align-items-xs-flex-start`` props = Custom ("align-items-xs-flex-start``", props)
        let inline ``Direction-xs-column-reverse`` props = Custom ("direction-xs-column-reverse``", props)
        let inline ``Direction-xs-column`` props = Custom ("direction-xs-column``", props)
        let inline ``Direction-xs-row-reverse`` props = Custom ("direction-xs-row-reverse``", props)
        let inline ``Grid-xs-10`` props = Custom ("grid-xs-10``", props)
        let inline ``Grid-xs-11`` props = Custom ("grid-xs-11``", props)
        let inline ``Grid-xs-12`` props = Custom ("grid-xs-12``", props)
        let inline ``Grid-xs-1`` props = Custom ("grid-xs-1``", props)
        let inline ``Grid-xs-2`` props = Custom ("grid-xs-2``", props)
        let inline ``Grid-xs-3`` props = Custom ("grid-xs-3``", props)
        let inline ``Grid-xs-4`` props = Custom ("grid-xs-4``", props)
        let inline ``Grid-xs-5`` props = Custom ("grid-xs-5``", props)
        let inline ``Grid-xs-6`` props = Custom ("grid-xs-6``", props)
        let inline ``Grid-xs-7`` props = Custom ("grid-xs-7``", props)
        let inline ``Grid-xs-8`` props = Custom ("grid-xs-8``", props)
        let inline ``Grid-xs-9`` props = Custom ("grid-xs-9``", props)
        let inline ``Grid-xs-auto`` props = Custom ("grid-xs-auto``", props)
        let inline ``Grid-xs-true`` props = Custom ("grid-xs-true``", props)
        let inline ``Justify-xs-center`` props = Custom ("justify-xs-center``", props)
        let inline ``Justify-xs-flex-end`` props = Custom ("justify-xs-flex-end``", props)
        let inline ``Justify-xs-space-around`` props = Custom ("justify-xs-space-around``", props)
        let inline ``Justify-xs-space-between`` props = Custom ("justify-xs-space-between``", props)
        let inline ``Justify-xs-space-evenly`` props = Custom ("justify-xs-space-evenly``", props)
        let inline ``Spacing-xs-16`` props = Custom ("spacing-xs-16``", props)
        let inline ``Spacing-xs-24`` props = Custom ("spacing-xs-24``", props)
        let inline ``Spacing-xs-32`` props = Custom ("spacing-xs-32``", props)
        let inline ``Spacing-xs-40`` props = Custom ("spacing-xs-40``", props)
        let inline ``Spacing-xs-8`` props = Custom ("spacing-xs-8``", props)
        let inline ``Wrap-xs-nowrap`` props = Custom ("wrap-xs-nowrap``", props)
        let inline ``Wrap-xs-wrap-reverse`` props = Custom ("wrap-xs-wrap-reverse``", props)

    type [<Erase; RequireQualifiedAccess>] StyleType =
        | Styles of IStyles list
        | Func of (ITheme->IStyles list)

    type IClassNames = interface end

    type ClassNames =
        | AdornedStart of string
        | AdornedEnd of string
        | NotchedOutline of string
        | InputAdornedStart of string
        | InputAdornedEnd of string
        | Absolute of string
        | Action of string
        | ActionIcon of string
        | ActionIconActionPosLeft of string
        | Actions of string
        | AlignCenter of string
        | AlignJistify of string
        | AlignLeft of string
        | AlignRight of string
        | AlternativeLabel of string
        | AnchorOriginBottomCenter of string
        | AnchorOriginBottomLeft of string
        | AnchorOriginBottomRight of string
        | AnchorOriginTopCenter of string
        | AnchorOriginTopLeft of string
        | AnchorOriginTopRight of string
        | Animated of string
        | Asterisk of string
        | Avatar of string
        | AvatarChildren of string
        | Badge of string
        | Bar of string
        | Bar1Buffer of string
        | Bar1Determinate of string
        | Bar1Indeterminate of string
        | Bar2Buffer of string
        | Bar2Determinate of string
        | Bar2Indeterminate of string
        | BarColorPrimary of string
        | BarColorSecondary of string
        | Body of string
        | Body1 of string
        | Body2 of string
        | Buffer of string
        | Button of string
        | Caption of string
        | Centered of string
        | Checked of string
        | Child of string
        | ChildLeaving of string
        | ChildPulsate of string
        | Circle of string
        | CircleIndeterminate of string
        | CircleStatic of string
        | Clickable of string
        | ColorAction of string
        | ColorDefault of string
        | ColorDisabled of string
        | ColorError of string
        | ColorInherit of string
        | ColorPrimary of string
        | ColorSecondary of string
        | ColorTextPrimary of string
        | ColorTextSecondary of string
        | Completed of string
        | Contained of string
        | ContainedPrimary of string
        | ContainedSecondary of string
        | Container of string
        | Content of string
        | Dashed of string
        | DashedColorPrimary of string
        | DashedColorSecondary of string
        | Default of string
        | Deletable of string
        | DeleteIcon of string
        | Dense of string
        | Disabled of string
        | Display1 of string
        | Display2 of string
        | Display3 of string
        | Display4 of string
        | Divider of string
        | Docked of string
        | Dot of string
        | DotActive of string
        | Dots of string
        | Elevation0 of string
        | Elevation1 of string
        | Elevation10 of string
        | Elevation11 of string
        | Elevation12 of string
        | Elevation13 of string
        | Elevation14 of string
        | Elevation15 of string
        | Elevation16 of string
        | Elevation17 of string
        | Elevation18 of string
        | Elevation19 of string
        | Elevation2 of string
        | Elevation20 of string
        | Elevation21 of string
        | Elevation22 of string
        | Elevation23 of string
        | Elevation24 of string
        | Elevation3 of string
        | Elevation4 of string
        | Elevation5 of string
        | Elevation6 of string
        | Elevation7 of string
        | Elevation8 of string
        | Elevation9 of string
        | Entered of string
        | Error of string
        | ExpandIcon of string
        | Expanded of string
        | ExtendedFab of string
        | Fab of string
        | Filled of string
        | Fixed of string
        | Flat of string
        | FlatPrimary of string
        | FlatSecondary of string
        | FlexContainer of string
        | FocusVisible of string
        | FocusHiglight of string
        | Focused of string
        | FontSizeInherit of string
        | Footer of string
        | Form of string
        | FormControl of string
        | FullWidth of string
        | GutterBottom of string
        | Gutters of string
        | H1 of string
        | H2 of string
        | H3 of string
        | H4 of string
        | H5 of string
        | H6 of string
        | Subtitle1 of string
        | Subtitle2 of string
        | Overline of string
        | SrOnly of string
        | Head of string
        | Headline of string
        | Hidden of string
        | Horizontal of string
        | Hover of string
        | Icon of string
        | IconContainer of string
        | IconDirectionAsc of string
        | IconDirectionDesc of string
        | Img of string
        | ImgFullHeight of string
        | ImgFullWidth of string
        | Indeterminate of string
        | Indicator of string
        | Input of string
        | InputMarginDense of string
        | InputMultiline of string
        | InputType of string
        | InputTypeSearch of string
        | Inset of string
        | Invisible of string
        | Item of string
        | Label of string
        | LabelContainer of string
        | LabelIcon of string
        | LabelPlacementStart of string
        | LabelWrapped of string
        | Last of string
        | Layout of string
        | Light of string
        | Line of string
        | LineHorizontal of string
        | LineVertical of string
        | MarginDense of string
        | MarginNormal of string
        | Media of string
        | MenuItem of string
        | Message of string
        | Mini of string
        | Modal of string
        | Multiline of string
        | NoWrap of string
        | Numeric of string
        | Outlined of string
        | OutlinedPrimary of string
        | OutlinedSecondary of string
        | Padding of string
        | PaddingCheckbox of string
        | PaddingDense of string
        | PaddingNone of string
        | Paper of string
        | PaperAnchorBottom of string
        | PaperAnchorDockedBottom of string
        | PaperAnchorDockedLeft of string
        | PaperAnchorDockedRight of string
        | PaperAnchorDockedTop of string
        | PaperAnchorLeft of string
        | PaperAnchorRight of string
        | PaperAnchorTop of string
        | PaperFullScreen of string
        | PaperFullWidth of string
        | PaperScrollBody of string
        | PaperScrollPaper of string
        | PaperWidthMd of string
        | PaperWidthSm of string
        | PaperWidthXs of string
        | Paragraph of string
        | Popper of string
        | PositionAbsolute of string
        | PositionBottom of string
        | PositionEnd of string
        | PositionFixed of string
        | PositionStart of string
        | PositionStatic of string
        | PositionSticky of string
        | PositionTop of string
        | Primary of string
        | Progress of string
        | Query of string
        | Raised of string
        | RaisedPrimary of string
        | RaisedSecondary of string
        | Required of string
        | Regular of string
        | Ripple of string
        | RipplePulsate of string
        | RippleVisible of string
        | Root of string
        | RootSubtitle of string
        | Rounded of string
        | Row of string
        | ScrollBody of string
        | ScrollButtons of string
        | ScrollButtonsAuto of string
        | ScrollPaper of string
        | Scrollable of string
        | Scroller of string
        | Secondary of string
        | SecondaryAction of string
        | Select of string
        | SelectIcon of string
        | SelectMenu of string
        | SelectRoot of string
        | Selected of string
        | Shrink of string
        | SizeLarge of string
        | SizeSmall of string
        | Spacer of string
        | Static of string
        | Sticky of string
        | Subheader of string
        | Subheading of string
        | Subtitle of string
        | Svg of string
        | SwitchBase of string
        | Text of string
        | TextColorInherit of string
        | TextColorPrimary of string
        | TextColorSecondary of string
        | TextDense of string
        | TextPrimary of string
        | TextSecondary of string
        | Tile of string
        | Title of string
        | TitlePositionBottom of string
        | TitlePositionTop of string
        | TitleWrap of string
        | TitleWrapActionPosLeft of string
        | TitleWrapActionPosRight of string
        | Toolbar of string
        | Tooltip of string
        | TooltipPlacementBottom of string
        | TooltipPlacementLeft of string
        | TooltipPlacementRight of string
        | TooltipPlacementTop of string
        | Touch of string
        | TouchRipple of string
        | Transition of string
        | Underline of string
        | Vertical of string
        | Wrapper of string
        | WrapperInner of string
        | ZeroMinWidth of string
        | ``Align-content-xs-center`` of string
        | ``Align-content-xs-flex-end`` of string
        | ``Align-content-xs-flex-start`` of string
        | ``Align-content-xs-space-around`` of string
        | ``Align-content-xs-space-between`` of string
        | ``Align-items-xs-baseline`` of string
        | ``Align-items-xs-center`` of string
        | ``Align-items-xs-flex-end`` of string
        | ``Align-items-xs-flex-start`` of string
        | ``Direction-xs-column-reverse`` of string
        | ``Direction-xs-column`` of string
        | ``Direction-xs-row-reverse`` of string
        | ``Grid-xs-10`` of string
        | ``Grid-xs-11`` of string
        | ``Grid-xs-12`` of string
        | ``Grid-xs-1`` of string
        | ``Grid-xs-2`` of string
        | ``Grid-xs-3`` of string
        | ``Grid-xs-4`` of string
        | ``Grid-xs-5`` of string
        | ``Grid-xs-6`` of string
        | ``Grid-xs-7`` of string
        | ``Grid-xs-8`` of string
        | ``Grid-xs-9`` of string
        | ``Grid-xs-auto`` of string
        | ``Grid-xs-true`` of string
        | ``Justify-xs-center`` of string
        | ``Justify-xs-flex-end`` of string
        | ``Justify-xs-space-around`` of string
        | ``Justify-xs-space-between`` of string
        | ``Justify-xs-space-evenly`` of string
        | ``Spacing-xs-16`` of string
        | ``Spacing-xs-24`` of string
        | ``Spacing-xs-32`` of string
        | ``Spacing-xs-40`` of string
        | ``Spacing-xs-8`` of string
        | ``Wrap-xs-nowrap`` of string
        | ``Wrap-xs-wrap-reverse`` of string
        | [<Erase>] Custom of string * string
        interface IClassNames

[<AutoOpen>]
module Colors =
    open Fable.Core.JsInterop
    open Themes
    let red = importDefault<IColor> "@material-ui/core/colors/red"
    let pink = importDefault<IColor> "@material-ui/core/colors/pink"
    let purple = importDefault<IColor> "@material-ui/core/colors/purple"
    let deepPurple = importDefault<IColor> "@material-ui/core/colors/deepPurple"
    let indigo = importDefault<IColor> "@material-ui/core/colors/indigo"
    let blue = importDefault<IColor> "@material-ui/core/colors/blue"
    let lightBlue = importDefault<IColor> "@material-ui/core/colors/lightBlue"
    let cyan = importDefault<IColor> "@material-ui/core/colors/cyan"
    let teal = importDefault<IColor> "@material-ui/core/colors/teal"
    let green = importDefault<IColor> "@material-ui/core/colors/green"
    let lightGreen = importDefault<IColor> "@material-ui/core/colors/lightGreen"
    let lime = importDefault<IColor> "@material-ui/core/colors/lime"
    let yellow = importDefault<IColor> "@material-ui/core/colors/yellow"
    let amber = importDefault<IColor> "@material-ui/core/colors/amber"
    let orange = importDefault<IColor> "@material-ui/core/colors/orange"
    let deepOrange = importDefault<IColor> "@material-ui/core/colors/deepOrange"
    let brown = importDefault<IColor> "@material-ui/core/colors/brown"
    let grey = importDefault<IColor> "@material-ui/core/colors/grey"
    let blueGrey = importDefault<IColor> "@material-ui/core/colors/blueGrey"

[<AutoOpen>]
module Props =
    open Fable.Core
    open Fable.Core.JsInterop
    open Fable.Helpers.React.Props

    let inline private customHtmlAttr key props =
        HTMLAttr.Custom(key, props |> keyValueList CaseRules.LowerFirst)

    type [<StringEnum; RequireQualifiedAccess>] MouseEvent = OnClick | OnMouseDown | OnMouseUp
    type [<StringEnum; RequireQualifiedAccess>] TouchEvent = OnTouchStart | OnTouchEnd
    type [<StringEnum; RequireQualifiedAccess>] MaterialSize = Xs | Sm | Md | Lg | Xl
    type [<StringEnum; RequireQualifiedAccess>] Anchor = Left | Top | Right | Bottom
    type [<StringEnum; RequireQualifiedAccess>] AutoEnum = Auto
    type [<StringEnum; RequireQualifiedAccess>] FormControlMargin = None | Dense | Normal
    type [<StringEnum; RequireQualifiedAccess>] SelectionControlColor =
        | Primary
        | Secondary
        | Default
    type [<StringEnum; RequireQualifiedAccess>] ComponentColor =
        | Default
        | Inherit
        | Primary
        | Secondary

    type [<StringEnum; RequireQualifiedAccess>] PlacementType =
        | [<CompiledName "bottom-end">] BottomEnd
        | [<CompiledName "bottom-start">] BottomStart
        | Bottom
        | [<CompiledName "left-end">] LeftEnd
        | [<CompiledName "left-start">] LeftStart
        | Left
        | [<CompiledName "right-end">] RightEnd
        | [<CompiledName "right-start">] RightStart
        | Right
        | [<CompiledName "top-end">] TopEnd
        | [<CompiledName "top-start">] TopStart
        | Top

    type StyleOption =
        | WithTheme of bool
        | Name of string
        | Flip of bool

    type TransitionDurationProp =
        | Enter of float
        | Exit of float

    type TransitionDuration = U2<float, TransitionDurationProp list>
    let inline private transitionDurationToHtmlAttr key (duration : TransitionDuration) =
        let prop = match duration with
                   | U2.Case1 float -> float
                   | U2.Case2 props -> props |> keyValueList CaseRules.LowerFirst |> unbox
        HTMLAttr.Custom(key, prop)

    type AutoTransitionDuration = U3<float, TransitionDuration list, AutoEnum>
    let inline private autoTransitionDurationToHtmlAttr key (duration : AutoTransitionDuration) =
        let prop = match duration with
                   | U3.Case1 float -> float
                   | U3.Case2 props -> props |> keyValueList CaseRules.LowerFirst |> unbox
                   | U3.Case3 auto -> auto |> unbox
        HTMLAttr.Custom (key, prop)

    type RefProp = U2<obj,(Fable.Import.React.ReactInstance->unit)>

    type MaterialProp =
        | Active of bool
        | AnchorEl of Fable.Import.React.ReactInstance
        | CheckedIcon of Fable.Import.React.ReactNode
        | Color of ComponentColor
        | Component of Fable.Import.React.ReactType
        | Container of Fable.Import.React.ReactInstance
        | Dense of bool
        | DisableGutters of bool
        | DisablePortal of bool
        | DisableRipple of bool
        | DisableTypography of bool
        | Elevation of int
        | Error of bool
        | FullWidth of bool
        | Icon of Fable.Import.React.ReactNode
        | In of bool
        | InputRef of RefProp
        | Inset of bool
        | KeepMounted of bool
        | Label of Fable.Import.React.ReactNode
        | Margin of FormControlMargin
        | Multiline of bool
        | Open of bool
        | Optional of Fable.Import.React.ReactNode
        | Placement of PlacementType
        | RowsMax of int
        | Value of obj // ? Should it be strongly typed? Like U{N}<string, int, float, decimal, arrays...>

        | OnClose of (obj->unit)
        | OnEnter of (obj->unit)
        | OnEntered of (obj->unit)
        | OnEntering of (obj->unit)
        | OnExit of (obj->unit)
        | OnExited of (obj->unit)
        | OnExiting of (obj->unit)
        | OnOpen of (obj->unit)
        | OnRendered of (obj->unit)
        interface IHTMLProp
    
    [<AutoOpen>]
    module MaterialProp =
        open Fable.Core.JsInterop
        let inline Classes (classNames : IClassNames list) =
            customHtmlAttr "classes" classNames
        let inline InputProps (props : IHTMLProp list) =
            customHtmlAttr "inputProps" props
        let Timeout = transitionDurationToHtmlAttr "timeout"
        let TransitionDuration = transitionDurationToHtmlAttr "transitionDuration"
        let TransitionDurationAuto = autoTransitionDurationToHtmlAttr "transitionDuration"

    type TransitionProp =
        | MountOnEnter of bool
        | UnmountOnExit of bool
        | Appear of bool
        | Enter of bool
        | Exit of bool
        | AddEndListener of (obj->(obj->unit)->unit)
        interface IHTMLProp

    type SelectionControlProp =
        | Color of SelectionControlColor
        | OnChange of (Fable.Import.React.FormEvent->bool->unit)
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] AppBarPosition =
        | Fixed
        | Absolute
        | Sticky
        | Static
        | Relative

    type AppBarProp =
        | Position of AppBarPosition
        interface IHTMLProp

    type AvatarProp =
        | Sizes of string
        interface IHTMLProp
    
    [<AutoOpen>]
    module AvatarProp =
        let inline ImgProps (props : IHTMLProp list) = customHtmlAttr "imgProps" props

    type BackdropProp =
        | Invisible of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] BadgeColor = Default | Primary | Secondary | Error

    type BadgeProp =
        | Color of BadgeColor
        | BadgeContent of Fable.Import.React.ReactNode
        interface IHTMLProp

    type BottomNavigationProp =
        | OnChange of (obj->obj->unit)
        | ShowLabels of bool
        | Value of obj
        interface IHTMLProp

    type BottomNavigationActionProp =
        | ShowLabel of bool
        | Value of obj
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] ButtonSize =
        | Small
        | Medium
        | Large

    type [<StringEnum; RequireQualifiedAccess>] ButtonVariant =
        | Text
        | [<Obsolete("Material-UI@3.2.0: The `flat` Button variant will be removed in the next major release of Material-UI. `text` is equivalent and should be used instead.")>]
            Flat
        | Outlined
        | Contained
        | [<Obsolete("Material-UI@3.2.0: The `raised` Button variant will be removed in the next major release of Material-UI. `contained` is equivalent and should be used instead.")>]
            Raised
        | Fab
        | ExtendedFab

    type ButtonProp =
        | DisableFocusRipple of bool
        | Href of string
        | Mini of bool
        | Size of ButtonSize
        | Variant of ButtonVariant
        interface IHTMLProp

    type IButtonBaseActions =
        abstract member focusVisible: unit -> bool

    type [<StringEnum; RequireQualifiedAccess>] ButtonBaseType =
        | Button
        | Submit
        | Reset

    type ButtonBaseProp =
        | Action of (IButtonBaseActions->unit)
        | ButtonRef of RefProp
        | CenterRipple of bool
        | DisableTouchRipple of bool
        | FocusRipple of bool
        | FocusVisibleClassName of string
        | OnFocusVisible of (Fable.Import.React.FocusEvent->unit)
        | Type of ButtonBaseType
        interface IHTMLProp

    type CardProp =
        | Raised of bool
        interface IHTMLProp

    type CardActionsProp =
        | DisableActionSpacing of bool
        interface IHTMLProp

    type CardHeaderProp =
        | Action of Fable.Import.React.ReactNode
        | Avatar of Fable.Import.React.ReactNode
        | Subheader of Fable.Import.React.ReactNode
        | Title of Fable.Import.React.ReactNode
        interface IHTMLProp
    
    [<AutoOpen>]
    module CardHeaderProp =
        let inline SubheaderTypographyProps (props : IHTMLProp list) =
            customHtmlAttr "subheaderTypographyProps" props
        let inline TitleTypographyProps (props : IHTMLProp list) =
            customHtmlAttr "titleTypographyProps" props

    type CardMediaProp =
        | Image of string
        interface IHTMLProp

    type CheckboxProp =
        | Indeterminate of bool
        | IndeterminateIcon of Fable.Import.React.ReactNode
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] ChipVariant = Default | Outlined
    type ChipProp =
        | Avatar of Fable.Import.React.ReactElement
        | Clickable of bool
        | DeleteIcon of Fable.Import.React.ReactElement
        | OnDelete of (Fable.Import.React.FormEvent->unit)
        | Variant of ChipVariant
        interface IHTMLProp

    type CircularProgressSize = U2<int, string>

    type [<StringEnum; RequireQualifiedAccess>] CircularProgressVariant =
        | Determinate
        | Indeterminate
        | Static

    type CircularProgressProp =
        | Size of CircularProgressSize
        | Thickness of float
        | Value of int // TODO validate for 0 to 100
        | Variant of CircularProgressVariant
        interface IHTMLProp

    type [<Erase>] ClickAwayListenerMouseEvent =
        | Event of MouseEvent
        | False

    type [<Erase>] ClickAwayListenerTouchEvent =
        | Event of TouchEvent
        | False

    type ClickAwayListenerProp =
        | OnClickAway of (obj->unit)
        | MouseEvent of ClickAwayListenerMouseEvent
        | TouchEvent of ClickAwayListenerTouchEvent
        interface IHTMLProp

    type CollapseProp =
        | CollapseHeight of string
        | Timeout of AutoTransitionDuration
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] DialogScroll = Body | Paper
    type [<StringEnum; RequireQualifiedAccess>] DialogMaxWidth =
        | Xs
        | Sm
        | Md
        | Lg
        | [<CompiledName("")>] False

    type DialogProp =
        | FullScreen of bool
        | MaxWidth of DialogMaxWidth
        | Scroll of DialogScroll
        interface IHTMLProp

    type DialogActionsProp =
        | DisableActionSpacing of bool
        interface IHTMLProp

    type DividerProp =
        | Absolute of bool
        | Light of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] DrawerVariant = Permanent | Persistent | Temporary

    type DrawerProp =
        | Anchor of Anchor
        | Variant of DrawerVariant
        interface IHTMLProp

    type ExpansionPanelProp =
        | Expanded of bool
        | DefaultExpanded of bool
        | OnChange of (obj->bool->unit)
        interface IHTMLProp

    type ExpansionPanelSummaryProp =
        | ExpandIcon of Fable.Import.React.ReactNode
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] FormControlLabelPlacement = End | Start

    type FormControlLabelProp =
        | Control of Fable.Import.React.ReactElement
        | LabelPlacement of FormControlLabelPlacement
        | OnChange of (obj->bool->unit)
        interface IHTMLProp

    type FormGroupProp =
        | Row of bool
        interface IHTMLProp

    type FormLabelProp =
        | Focused of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] GridAlignContent =
        | Stretch
        | Center
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | [<CompiledName("space-between")>] SpaceBetween
        | [<CompiledName("space-around")>] SpaceAround

    type [<StringEnum; RequireQualifiedAccess>] GridJustify =
        | Center
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd
        | [<CompiledName("space-between")>] SpaceBetween
        | [<CompiledName("space-around")>] SpaceAround
        | [<CompiledName("space-evenly")>] SpaceEvenly

    type [<StringEnum; RequireQualifiedAccess>] GridAlignItems =
        | Stretch
        | Center
        | BaseLine
        | [<CompiledName("flex-start")>] FlexStart
        | [<CompiledName("flex-end")>] FlexEnd

    type [<StringEnum; RequireQualifiedAccess>] GridDirection =
        | Row
        | Column
        | [<CompiledName("row-reverse")>] RowReverse
        | [<CompiledName("column-reverse")>] ColumnReverse

    type [<RequireQualifiedAccess>] GridSpacing =
        | ``0`` = 0
        | ``8`` = 8
        | ``16`` = 16
        | ``24`` = 24
        | ``32`` = 32
        | ``40`` = 40

    type [<StringEnum; RequireQualifiedAccess>] GridWrap =
        | Nowrap
        | Wrap
        | [<CompiledName("wrap-reverse")>] WrapReverse

    type [<RequireQualifiedAccess>] GridSizeNum =
        | ``1`` = 1
        | ``2`` = 2
        | ``3`` = 3
        | ``4`` = 4
        | ``5`` = 5
        | ``6`` = 6
        | ``7`` = 7
        | ``8`` = 8
        | ``9`` = 9
        | ``10`` = 10
        | ``11`` = 11
        | ``12`` = 12

    type GridSize = U3<bool, AutoEnum, GridSizeNum>

    type GridProp =
        | AlignContent of GridAlignContent
        | AlignItems of GridAlignItems
        | Container of bool
        | Direction of GridDirection
        | Item of bool
        | Justify of GridJustify
        | Lg of GridSize
        | Md of GridSize
        | Sm of GridSize
        | Xl of GridSize
        | Xs of GridSize
        | Spacing of GridSpacing
        | Wrap of GridWrap
        | ZeroMinWidth of bool
        interface IHTMLProp

    type GridListCellHeight = U2<int, AutoEnum>
    type GridListProp =
        | CellHeight of GridListCellHeight
        | Spacing of int
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] ActionPosition = Left | Right
    type [<StringEnum; RequireQualifiedAccess>] TitlePosition = Top | Bottom

    type GridListTileBarProp =
        | ActionIcon of Fable.Import.React.ReactNode
        | ActionPosition of ActionPosition
        | Subtitle of Fable.Import.React.ReactNode
        | Title of Fable.Import.React.ReactNode
        | TitlePosition of TitlePosition
        interface IHTMLProp

    type GrowProp =
        | Timeout of AutoTransitionDuration
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] HiddenImplementation = Js | Css
    type HiddenOnly = U2<MaterialSize, MaterialSize list>

    type HiddenProp =
        | Implementation of HiddenImplementation
        | InitialWidth of MaterialSize
        | LgDown of bool
        | LgUp of bool
        | MdDown of bool
        | MdUp of bool
        | Only of HiddenOnly
        | SmDown of bool
        | SmUp of bool
        | XlDown of bool
        | XlUp of bool
        | XsDown of bool
        | XsUp of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] IconFontSize =
        | Inherit
        | Default
        | Small
        | Large

    type [<StringEnum; RequireQualifiedAccess>] IconColor =
        | Inherit
        | Primary
        | Secondary
        | Action
        | Error
        | Disabled

    type IconProp =
        | Color of IconColor
        | FontSize of IconFontSize
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] InputMargin = None | Dense

    type InputProp =
        | DisableUnderline of bool
        | EndAdornment of Fable.Import.React.ReactNode
        | InputComponent of Fable.Import.React.ReactType
        | StartAdornment of Fable.Import.React.ReactNode
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] InputAdornmentPosition = Start | End
    type [<StringEnum; RequireQualifiedAccess>] InputAdornmentVariant = Standard | Outlined | Filled

    type InputAdornmentProp =
        | Position of InputAdornmentPosition
        | Variant of InputAdornmentVariant
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] InputLabelMargin = Dense
    type [<StringEnum; RequireQualifiedAccess>] InputLabelVariant = Standard | Outlined | Filled

    type InputLabelProp =
        | DisableAnimation of bool
        | Margin of InputLabelMargin
        | Shrink of bool
        | Variant of InputLabelVariant
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] LinearProgressColor = Primary | Secondary
    type [<StringEnum; RequireQualifiedAccess>] LinearProgressVariant =
        | Determinate
        | Indeterminate
        | Buffer
        | Query

    type LinearProgressProp =
        | Color of LinearProgressColor
        | ValueBuffer of int
        | Variant of LinearProgressVariant
        interface IHTMLProp

    type ListProp =
        | DisablePadding of bool
        | Subheader of Fable.Import.React.ReactElement
        interface IHTMLProp

    type ListItemProp =
        | Button of bool
        | Divider of bool
        interface IHTMLProp

    type ListItemTextProp =
        | Primary of Fable.Import.React.ReactNode
        | Secondary of Fable.Import.React.ReactNode
        interface IHTMLProp
    
    [<AutoOpen>]
    module ListItemTextProp =
        let inline PrimaryTypographyProps (props : IHTMLProp list) =
            customHtmlAttr "primaryTypographyProps" props
        let inline SecondaryTypographyProps (props : IHTMLProp list) =
            customHtmlAttr "secondaryTypographyProps" props

    type [<StringEnum; RequireQualifiedAccess>] ListSubheaderColor = Default | Primary | Inherit

    type ListSubheaderProp =
        | Color of ListSubheaderColor
        | DisableSticky of bool
        interface IHTMLProp

    type MenuProp =
        | DisableAutoFocusItem of bool
        interface IHTMLProp
    
    type [<StringEnum; RequireQualifiedAccess>] MobileStepperPosition = Bottom | Top | Static
    type [<StringEnum; RequireQualifiedAccess>] MobileStepperVariant = Text | Dots | Progress

    type MobileStepperProp =
        | ActiveStep of int
        | BackButton of Fable.Import.React.ReactElement
        | NextButton of Fable.Import.React.ReactElement
        | Position of MobileStepperPosition
        | Steps of int
        | Variant of MobileStepperVariant
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] ModalCloseReason = EscapeKeyDown | BackdropClick

    type ModalProp =
        | DisableAutoFocus of bool
        | DisableBackdropClick of bool
        | DisableEnforceFocus of bool
        | DisableEscapeKeyDown of bool
        | DisableRestoreFocus of bool
        | HideBackdrop of bool
        | Manager of obj // TODO check static type for ModalManager
        | OnBackdropClick of (obj->unit)
        | OnEscapeKeyDown of (obj->unit)
        | OnClose of (obj->ModalCloseReason->unit)
        interface IHTMLProp

    type OutlinedInputProp =
        | Notched of bool
        interface IHTMLProp

    type PaperProp =
        | Square of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] PopoverHorizontalPosition = Left | Center | Right
    type [<StringEnum; RequireQualifiedAccess>] PopoverVerticalPosition = Top | Center | Bottom
    type [<StringEnum; RequireQualifiedAccess>] AnchorReference = AnchorEl | AnchorPosition | None
    and  AnchorPosition = {
        left: int
        top: int
    }

    type PopoverHorizontalOrigin = U2<int,PopoverHorizontalPosition>
    type PopoverVerticalOrigin = U2<int,PopoverVerticalPosition>
    type  PopoverOrigin = {
        horizontal: PopoverHorizontalOrigin
        vertical: PopoverVerticalOrigin
    }

    type IPopoverActions =
        abstract member updatePosition: unit -> unit

    type PopoverProp =
        | Action of (IPopoverActions->unit)
        | AnchorOrigin of PopoverOrigin
        | AnchorPosition of AnchorPosition
        | AnchorReference of AnchorReference
        | GetContentAnchorEl of (obj->obj)
        | MarginThreshold of int
        | TransformOrigin of PopoverOrigin
        interface IHTMLProp
    
    type PopperProp =
        | Modifies of obj
        | PopperOptions of obj
        | Transition of bool
        interface IHTMLProp

    type RadioGroupProp =
        | OnChange of (obj->string->unit)
        interface IHTMLProp

    type RootRefProp =
        | RootRef of RefProp
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] SelectVariant = Standard | Outlined | Filled
    type SelectProp =
        | AutoWidth of bool
        | DisplayEmpty of bool
        | Input of Fable.Import.React.ReactNode
        | Native of bool
        | OnChange of (obj->obj->unit)
        | RenderValue of (obj->Fable.Import.React.ReactNode)
        | Variant of SelectVariant
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] SlideDirection = Bottom | Up | Left | Right

    type SlideProp =
        | Direction of SlideDirection
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] SnackbarHorizontalOrigin = Left | Center | Right
    type [<StringEnum; RequireQualifiedAccess>] SnackbarVerticalOrigin = Top | Center | Bottom
    type [<StringEnum; RequireQualifiedAccess>] SnackbarCloseReason = Timeout | Clickaway

    type  SnackbarOrigin = {
        vertical: SnackbarVerticalOrigin
        horizontal: SnackbarHorizontalOrigin
    }

    type SnackbarProp =
        | Action of Fable.Import.React.ReactElement
        | AnchorOrigin of SnackbarOrigin
        | AutoHideDuration of int
        | DisableWidnowBlurListener of bool
        | Message of Fable.Import.React.ReactElement
        | OnClose of (obj->SnackbarCloseReason->unit)
        | ResumeHideDuration of int
        interface IHTMLProp

    type StepProp =
        | Completed of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] StepperOrientation = Vertical | Horizontal

    type StepperProp =
        | ActiveStep of int
        | AlternativeLabel of bool
        | Connector of Fable.Import.React.ReactElement
        | NonLinear of bool
        | Orientation of StepperOrientation
        interface IHTMLProp

    type SvgIconProp =
        | NativeColor of string
        | TitleAccess of string
        interface IHTMLProp

    type SwipeableDrawerProp =
        | DisableBackdropTransition of bool
        | DisableDiscovery of bool
        | DisableSwipeToOpen of bool
        | SwipeAreaWidth of int
        | Hysteresis of float
        | MinFlingVelocity of int
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] TabsIndicatorColor = Primary | Secondary
    type [<StringEnum; RequireQualifiedAccess>] TabsTextColor = Primary | Secondary | Inherit
    type [<StringEnum; RequireQualifiedAccess>] ScrollButtonsType = Auto | On | Off

    type ITabsActions =
        abstract member updateIndicator: unit -> unit

    type TabsProp =
        | Action of (ITabsActions->unit)
        | Centered of bool
        | IndicatorColor of TabsIndicatorColor
        | OnChange of (obj->int->unit)
        | Scrollabel of bool
        | ScrollButtons of ScrollButtonsType
        | TextColor of TabsTextColor
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] TableCellPadding = Default | Checkbox | Dense | None
    type [<StringEnum; RequireQualifiedAccess>] TableCellVariant = Head | Body | Footer
    type [<StringEnum; RequireQualifiedAccess>] TableCellSortDirection =
        | Asc
        | Desc
        | [<CompiledName("")>] False

    type TableCellProp =
        | Numeric of bool
        | Padding of TableCellPadding
        | Scope of string
        | SortDirection of TableCellSortDirection
        | Variant of TableCellVariant
        interface IHTMLProp

    type ILabelDisplayedRowsArgs =
        abstract member from: int
        abstract member ``to``: int
        abstract member count: int
        abstract member page: int

    type TablePaginationProp =
        | Count of int
        | LabelDisplayedRows of (ILabelDisplayedRowsArgs->Fable.Import.React.ReactNode)
        | LabelRowsPerPage of Fable.Import.React.ReactNode
        | OnChangePage of (obj->int->unit)
        | OnChangeRowsPerPage of (obj->unit)
        | Page of int
        | RowsPerPage of int
        | RowsPerPageOptions of int list
        interface IHTMLProp
    
    [<AutoOpen>]
    module TablePaginationProp =
        let inline BackIconButtonProps (props : IHTMLProp list) =
            customHtmlAttr "backIconButtonProps" props
        let inline NextIconButtonProps (props : IHTMLProp list) =
            customHtmlAttr "nextIconButtonProps" props

    type TableRowProp =
        | Hover of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] TableSortDirection = Asc | Desc
    type TableSortLabelProp =
        | Direction of TableSortDirection
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] TextFieldVariant =
        | Standard
        | Outlined
        | Filled

    type TextFieldProp =
        | HelperText of Fable.Import.React.ReactNode
        | Select of bool
        | Variant of TextFieldVariant
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] ToolbarVariant = Regular | Dense
    type ToolbarProp =
        | Variant of ToolbarVariant
        interface IHTMLProp

    type TooltipProp =
        | DisableFocusListener of bool
        | DisableHoverListener of bool
        | DisableTouchListener of bool
        | EnterDelay of int
        | EnterTouchDelay of int
        | LeaveDelay of int
        | LeaveTouchDelay of int
        | Title of Fable.Import.React.ReactNode
        interface IHTMLProp

    type TouchRippleProp =
        | Center of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] TypographyAlign =
        | Inherit
        | Left
        | Center
        | Right
        | Justify

    type [<StringEnum; RequireQualifiedAccess>] TypographyColor =
        | Default
        | Error
        | Inherit
        | Primary
        | Secondary
        | TextPrimary
        | TextSecondary

    type [<StringEnum; RequireQualifiedAccess>] TypographyVariant =
        | H1
        | H2
        | H3
        | H4
        | H5
        | H6
        | Subtitle1
        | Subtitle2
        | Overline
        | SrOnly
        | Body1
        | Body2
        | Caption
        | Button
        | Inherit
        // Depreceted
        | [<Obsolete("Material-UI@3.2.0: Typography type `Display1` is deprecated. Please use `H4` instead")>] Display1
        | [<Obsolete("Material-UI@3.2.0: Typography type `Display2` is deprecated. Please use `H3` instead")>] Display2
        | [<Obsolete("Material-UI@3.2.0: Typography type `Display3` is deprecated. Please use `H2` instead")>] Display3
        | [<Obsolete("Material-UI@3.2.0: Typography type `Display4` is deprecated. Please use `H1` instead")>] Display4
        | [<Obsolete("Material-UI@3.2.0: Typography type `Headline` is deprecated. Please use `H5` instead")>] Headline
        | [<Obsolete("Material-UI@3.2.0: Typography type `Title` is deprecated. Please use `H6` instead")>] Title
        | [<Obsolete("Material-UI@3.2.0: Typography type `Subheading` is deprecated. Please use `Subtitle1` instead")>] Subheading

    type TypographyProp =
        | Align of TypographyAlign
        | Color of TypographyColor
        | GutterBottom of bool
        | HeadlineMapping of obj // TODO strong type
        | NoWrap of bool
        | Paragraph of bool
        | Variant of TypographyVariant
        interface IHTMLProp

    type PaletteCommonProp =
        | Black of string
        | White of string

    type PaletteIntentionProp =
        | Light of string
        | Main of string
        | Dark of string
        | ContrastText of string

    type ColorType () =
        static member ``50`` = "50"
        static member ``100`` = "100"
        static member ``200`` = "200"
        static member ``300`` = "300"
        static member ``400`` = "400"
        static member ``500`` = "500"
        static member ``600`` = "600"
        static member ``700`` = "700"
        static member ``800`` = "800"
        static member ``900`` = "900"
        static member A100 = "A100"
        static member A200 = "A200"
        static member A400 = "A400"
        static member A700 = "A700"

    type PaletteTextProp =
        | Primary of string
        | Secondary of string
        | Disabled of string
        | Hint of string

    type PaletteBackgroundProp =
        | Paper of string
        | Default of string

    type PaletteActionProp =
        | Active of string
        | Hover of string
        | HoverOpacity of float
        | Selected of string
        | Disabled of string
        | DisabledBackground of string

    type PaletteProp =
        | Type of Themes.PaletteType
        | ContrastThreshold of int
        | TonalOffset of float
        | Divider of string
        | [<Erase>] Custom of string*obj
    
    [<AutoOpen>]
    module PaletteProp =
        open Fable.Core.JsInterop
        let inline customPaletteProp key props = PaletteProp.Custom(key, props |> keyValueList CaseRules.LowerFirst)

        let inline Common (props : PaletteCommonProp list) = customPaletteProp "common" props
        let inline Primary (props : PaletteIntentionProp list) = customPaletteProp "primary" props
        let inline Secondary (props : PaletteIntentionProp list) = customPaletteProp "secondary" props
        let inline Error (props : PaletteIntentionProp list) = customPaletteProp "error" props
        let inline Grey (props : (string * obj) list) = customPaletteProp "grey" props
        let inline Text (props : PaletteTextProp list) = customPaletteProp "text" props
        let inline Background (props : PaletteBackgroundProp list) = customPaletteProp "background" props
        let inline Action (props : PaletteActionProp list) = customPaletteProp "action" props


    type TextStyleProp =
        | FontFamily of string
        | Color of string
        | FontSize of string
        | FontWeight of string
        | LetterSpacing of string
        | LineHeight of string
        | TextTransform of string

    type ThemeTypographyProp =
        | FontFamily of string
        | FontSize of string
        | FontWeightLight of int
        | FontWeightRegular of int
        | FontWeightMedium of int
        | HtmlFontSize of string
        | UseNextVariants of bool

        | [<Erase>] Custom of string*obj

    [<AutoOpen>]
    module ThemeTypographyProp =
        open Fable.Core.JsInterop
        let inline customThemeTypographyProp key props =
            ThemeTypographyProp.Custom (key, props |> keyValueList CaseRules.LowerFirst)
        let inline textStyleProps key (props : TextStyleProp list) =
            customThemeTypographyProp key props

        let inline AllVariants (props : CSSProp list) = customThemeTypographyProp "allVariants" props
        let H1 = textStyleProps "h1"
        let H2 = textStyleProps "h2"
        let H3 = textStyleProps "h3"
        let H4 = textStyleProps "h4"
        let H5 = textStyleProps "h5"
        let H6 = textStyleProps "h6"
        let Subtitle1 = textStyleProps "subtitle1"
        let Subtitle2 = textStyleProps "subtitle2"
        let Overline = textStyleProps "overline"
        let Body1 = textStyleProps "body1"
        let Body2 = textStyleProps "body2"
        let Caption = textStyleProps "caption"
        let Button = textStyleProps "button"

        [<Obsolete("Material-UI@3.2.0: Typography type `Display1` is deprecated. Please use `H4` instead")>]
        let Display1 = textStyleProps "display1"
        [<Obsolete("Material-UI@3.2.0: Typography type `Display2` is deprecated. Please use `H3` instead")>]
        let Display2 = textStyleProps "display2"
        [<Obsolete("Material-UI@3.2.0: Typography type `Display3` is deprecated. Please use `H2` instead")>]
        let Display3 = textStyleProps "display3"
        [<Obsolete("Material-UI@3.2.0: Typography type `Display4` is deprecated. Please use `H1` instead")>]
        let Display4 = textStyleProps "display4"
        [<Obsolete("Material-UI@3.2.0: Typography type `Headline` is deprecated. Please use `H5` instead")>]
        let Headline = textStyleProps "headline"
        [<Obsolete("Material-UI@3.2.0: Typography type `Title` is deprecated. Please use `H6` instead")>]
        let Title = textStyleProps "title"
        [<Obsolete("Material-UI@3.2.0: Typography type `Subheading` is deprecated. Please use `Subtitle1` instead")>]
        let Subheading = textStyleProps "subheading"


    type ShapeProp =
        | BorderRadius of int

    type SpacingProp =
        | Unit of int

    type ZIndexProp =
        | AppBar of int
        | Drawer of int
        | MobileStepper of int
        | Modal of int
        | Snackbar of int
        | Tooltip of int

    type IOverridesProp = interface end
    type OverridesProp =
        | [<Erase>] Custom of string * obj
        interface IOverridesProp

    [<AutoOpen>]
    module OverridesProp =
        open Fable.Core.JsInterop
        let inline private pascalCaseProp (name : string) (props : Themes.IStyles list) =
            OverridesProp.Custom (name, props |> keyValueList CaseRules.LowerFirst)

        let inline MuiAppBar styles = pascalCaseProp "MuiAppBar" styles
        let inline MuiAvatar styles = pascalCaseProp "MuiAvatar" styles
        let inline MuiBackdrop styles = pascalCaseProp "MuiBackdrop" styles
        let inline MuiBadge styles = pascalCaseProp "MuiBadge" styles
        let inline MuiBottomNavigation styles = pascalCaseProp "MuiBottomNavigation" styles
        let inline MuiBottomNavigationAction styles = pascalCaseProp "MuiBottomNavigationAction" styles
        let inline MuiButton styles = pascalCaseProp "MuiButton" styles
        let inline MuiButtonBase styles = pascalCaseProp "MuiButtonBase" styles
        let inline MuiCard styles = pascalCaseProp "MuiCard" styles
        let inline MuiCardActionArea styles = pascalCaseProp "MuiCardActionArea" styles
        let inline MuiCardActions styles = pascalCaseProp "MuiCardActions" styles
        let inline MuiCardContent styles = pascalCaseProp "MuiCardContent" styles
        let inline MuiCardHeader styles = pascalCaseProp "MuiCardHeader" styles
        let inline MuiCardMedia styles = pascalCaseProp "MuiCardMedia" styles
        let inline MuiCheckbox styles = pascalCaseProp "MuiCheckbox" styles
        let inline MuiChip styles = pascalCaseProp "MuiChip" styles
        let inline MuiCircularProgress styles = pascalCaseProp "MuiCircularProgress" styles
        let inline MuiCollapse styles = pascalCaseProp "MuiCollapse" styles
        let inline MuiCssBaseline styles = pascalCaseProp "MuiCssBaseline" styles
        let inline MuiDialog styles = pascalCaseProp "MuiDialog" styles
        let inline MuiDialogActions styles = pascalCaseProp "MuiDialogActions" styles
        let inline MuiDialogContent styles = pascalCaseProp "MuiDialogContent" styles
        let inline MuiDialogContentText styles = pascalCaseProp "MuiDialogContentText" styles
        let inline MuiDialogTitle styles = pascalCaseProp "MuiDialogTitle" styles
        let inline MuiDivider styles = pascalCaseProp "MuiDivider" styles
        let inline MuiDrawer styles = pascalCaseProp "MuiDrawer" styles
        let inline MuiExpansionPanel styles = pascalCaseProp "MuiExpansionPanel" styles
        let inline MuiExpansionPanelActions styles = pascalCaseProp "MuiExpansionPanelActions" styles
        let inline MuiExpansionPanelDetails styles = pascalCaseProp "MuiExpansionPanelDetails" styles
        let inline MuiExpansionPanelSummary styles = pascalCaseProp "MuiExpansionPanelSummary" styles
        let inline MuiFormControl styles = pascalCaseProp "MuiFormControl" styles
        let inline MuiFormControlLabel styles = pascalCaseProp "MuiFormControlLabel" styles
        let inline MuiFormGroup styles = pascalCaseProp "MuiFormGroup" styles
        let inline MuiFormHelperText styles = pascalCaseProp "MuiFormHelperText" styles
        let inline MuiFormLabel styles = pascalCaseProp "MuiFormLabel" styles
        let inline MuiGrid styles = pascalCaseProp "MuiGrid" styles
        let inline MuiGridList styles = pascalCaseProp "MuiGridList" styles
        let inline MuiGridListTile styles = pascalCaseProp "MuiGridListTile" styles
        let inline MuiGridListTileBar styles = pascalCaseProp "MuiGridListTileBar" styles
        let inline MuiIcon styles = pascalCaseProp "MuiIcon" styles
        let inline MuiIconButton styles = pascalCaseProp "MuiIconButton" styles
        let inline MuiInput styles = pascalCaseProp "MuiInput" styles
        let inline MuiInputAdornment styles = pascalCaseProp "MuiInputAdornment" styles
        let inline MuiInputLabel styles = pascalCaseProp "MuiInputLabel" styles
        let inline MuiLinearProgress styles = pascalCaseProp "MuiLinearProgress" styles
        let inline MuiList styles = pascalCaseProp "MuiList" styles
        let inline MuiListItem styles = pascalCaseProp "MuiListItem" styles
        let inline MuiListItemAvatar styles = pascalCaseProp "MuiListItemAvatar" styles
        let inline MuiListItemIcon styles = pascalCaseProp "MuiListItemIcon" styles
        let inline MuiListItemSecondaryAction styles = pascalCaseProp "MuiListItemSecondaryAction" styles
        let inline MuiListItemText styles = pascalCaseProp "MuiListItemText" styles
        let inline MuiListSubheader styles = pascalCaseProp "MuiListSubheader" styles
        let inline MuiMenu styles = pascalCaseProp "MuiMenu" styles
        let inline MuiMenuItem styles = pascalCaseProp "MuiMenuItem" styles
        let inline MuiMobileStepper styles = pascalCaseProp "MuiMobileStepper" styles
        let inline MuiModal styles = pascalCaseProp "MuiModal" styles
        let inline MuiNativeSelect styles = pascalCaseProp "MuiNativeSelect" styles
        let inline MuiOutlinedInput styles = pascalCaseProp "MuiOutlinedInput" styles
        let inline MuiPaper styles = pascalCaseProp "MuiPaper" styles
        let inline MuiPopover styles = pascalCaseProp "MuiPopover" styles
        let inline MuiRadio styles = pascalCaseProp "MuiRadio" styles
        let inline MuiSelect styles = pascalCaseProp "MuiSelect" styles
        let inline MuiSnackbar styles = pascalCaseProp "MuiSnackbar" styles
        let inline MuiSnackbarContent styles = pascalCaseProp "MuiSnackbarContent" styles
        let inline MuiStep styles = pascalCaseProp "MuiStep" styles
        let inline MuiStepButton styles = pascalCaseProp "MuiStepButton" styles
        let inline MuiStepConnector styles = pascalCaseProp "MuiStepConnector" styles
        let inline MuiStepContent styles = pascalCaseProp "MuiStepContent" styles
        let inline MuiStepIcon styles = pascalCaseProp "MuiStepIcon" styles
        let inline MuiStepLabel styles = pascalCaseProp "MuiStepLabel" styles
        let inline MuiStepper styles = pascalCaseProp "MuiStepper" styles
        let inline MuiSvgIcon styles = pascalCaseProp "MuiSvgIcon" styles
        let inline MuiSwitch styles = pascalCaseProp "MuiSwitch" styles
        let inline MuiTab styles = pascalCaseProp "MuiTab" styles
        let inline MuiTable styles = pascalCaseProp "MuiTable" styles
        let inline MuiTableCell styles = pascalCaseProp "MuiTableCell" styles
        let inline MuiTableFooter styles = pascalCaseProp "MuiTableFooter" styles
        let inline MuiTablePagination styles = pascalCaseProp "MuiTablePagination" styles
        let inline MuiTableRow styles = pascalCaseProp "MuiTableRow" styles
        let inline MuiTableSortLabel styles = pascalCaseProp "MuiTableSortLabel" styles
        let inline MuiTabs styles = pascalCaseProp "MuiTabs" styles
        let inline MuiToolbar styles = pascalCaseProp "MuiToolbar" styles
        let inline MuiTooltip styles = pascalCaseProp "MuiTooltip" styles
        let inline MuiTouchRipple styles = pascalCaseProp "MuiTouchRipple" styles
        let inline MuiTypography styles = pascalCaseProp "MuiTypography" styles


    type ThemeProp =
        | Direction of Themes.TextDirection
        | Shadows of string list
        | [<Erase>] Custom of string*obj

    [<AutoOpen>]
    module ThemeProp =
        open Fable.Core.JsInterop
        let inline customThemeProp key props = ThemeProp.Custom (key, props |> keyValueList CaseRules.LowerFirst)
        let inline Palette (props : PaletteProp list) = customThemeProp "palette" props
        let inline Shape (props : ShapeProp list) = customThemeProp "shape" props
        let inline Spacing (props : SpacingProp list) = customThemeProp "spacing" props
        let inline Typography (props : ThemeTypographyProp list) = customThemeProp "typography" props
        let inline ZIndex (props : ZIndexProp list) = customThemeProp "zIndex" props
        let inline Overrides (props : IOverridesProp list) = customThemeProp "overrides" props

    type [<Erase>] ProviderTheme =
        | Theme of Themes.ITheme
        | Func of (Themes.ITheme->ThemeProp list)

    type MuiThemeProviderProp =
        | Theme of ProviderTheme
        | DisableStylesGeneration of bool
        interface IHTMLProp

    type [<StringEnum; RequireQualifiedAccess>] Breakpoint = Xs | Sm | Md | Lg | Xl
    type [<AllowNullLiteral>] IWithWidthProps =
        abstract member width: Breakpoint

    type WithWidthOption =
        | WithTheme of bool
        | NoSSR of bool
        | InitialWidth of Breakpoint

    [<AutoOpen>]
    module ChildrenProp =
        open Fable.Core.JsInterop

        let inline private pascalCaseProp<'a> (name : string) (props : 'a list) =
            HTMLAttr.Custom (name, props |> keyValueList CaseRules.LowerFirst)
        let inline private htmlAttrPascalCaseProp (name : string) (props : IHTMLProp list) =
            pascalCaseProp<IHTMLProp> name props

        let inline PaperProps props = htmlAttrPascalCaseProp "PaperProps" props
        let inline BackdropProps props = htmlAttrPascalCaseProp "BackdropProps" props
        let inline SelectProps props = htmlAttrPascalCaseProp "SelectProps" props
        let inline TransitionProps props = htmlAttrPascalCaseProp "TransitionProps" props
        let inline TouchRippleProps props = htmlAttrPascalCaseProp "TouchRippleProps" props
        let inline ModalProps props = htmlAttrPascalCaseProp "ModalProps" props
        let inline SlideProps props = htmlAttrPascalCaseProp "SlideProps" props
        let inline CollapseProps props = htmlAttrPascalCaseProp "CollapseProps" props
        let inline PopperProps props = htmlAttrPascalCaseProp "PopperProps" props
        let inline InputProps props = htmlAttrPascalCaseProp "InputProps" props
        let inline InputLabelProps props = htmlAttrPascalCaseProp "InputLabelProps" props
        let inline FormHelperTextProps props = htmlAttrPascalCaseProp "FormHelperTextProps" props
        let inline TabIndicatorProps props = htmlAttrPascalCaseProp "TabIndicatorProps" props
        let inline StepIconProps props = htmlAttrPascalCaseProp "StepIconProps" props
        let inline ContentProps props = htmlAttrPascalCaseProp "ContentProps" props
        let inline SelectDisplayProps props = htmlAttrPascalCaseProp "SelectDisplayProps" props
        let inline MenuProps props = htmlAttrPascalCaseProp "MenuProps" props
        let inline LinearProgressProps props = htmlAttrPascalCaseProp "LinearProgressProps" props
        let inline MenuListProps props = htmlAttrPascalCaseProp "MenuListProps" props
        let inline ContainerProps props = htmlAttrPascalCaseProp "ContainerProps" props
        let inline IconButtonProps props = htmlAttrPascalCaseProp "IconButtonProps" props
        let inline ClickAwayListenerProps props = htmlAttrPascalCaseProp "ClickAwayListenerProps" props
        let inline PopoverClasses classes = pascalCaseProp<Themes.IClassNames> "PopoverClasses" classes
        let inline FormLabelClasses classes = pascalCaseProp<Themes.IClassNames> "FormLabelClasses" classes
        let inline ActionsComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("ActionsComponent", comp)
        let inline ScrollButtonComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("ScrollButtonComponent", comp)
        let inline StepIconComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("StepIconComponent", comp)
        let inline IconComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("IconComponent", comp)
        let inline BackdropComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("BackdropComponent", comp)
        let inline ContainerComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("ContainerComponent", comp)
        let inline TransitionComponent (comp : Fable.Import.React.ReactType) =
            HTMLAttr.Custom("TransitionComponent", comp)
