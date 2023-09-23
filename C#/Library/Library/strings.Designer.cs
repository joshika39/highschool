﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Library.strings", typeof(strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No.
        /// </summary>
        internal static string AnswerNo {
            get {
                return ResourceManager.GetString("AnswerNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Yes.
        /// </summary>
        internal static string AnswerYes {
            get {
                return ResourceManager.GetString("AnswerYes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Author of the book: .
        /// </summary>
        internal static string BookAuthor {
            get {
                return ResourceManager.GetString("BookAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of the book in the library is: {0}.
        /// </summary>
        internal static string BookNumberText {
            get {
                return ResourceManager.GetString("BookNumberText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title of the book: .
        /// </summary>
        internal static string BookTitle {
            get {
                return ResourceManager.GetString("BookTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Which book would you want to borrow?
        ///Please enter in it&apos;s ID: .
        /// </summary>
        internal static string BookToBorrow {
            get {
                return ResourceManager.GetString("BookToBorrow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Which book would you want to return?
        ///Please enter in it&apos;s ID: .
        /// </summary>
        internal static string BookToReturn {
            get {
                return ResourceManager.GetString("BookToReturn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no file for users or books yet. Add some!.
        /// </summary>
        internal static string ErrorBookFileNotFound {
            get {
                return ResourceManager.GetString("ErrorBookFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no file for users or books yet. Add some!.
        /// </summary>
        internal static string ErrorUserFileNotFound {
            get {
                return ResourceManager.GetString("ErrorUserFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to How to you want to modify?
        ///If you wish to perform something check the following commands:
        ///- &apos;d&apos; is for delete something..
        /// </summary>
        internal static string HowToModify {
            get {
                return ResourceManager.GetString("HowToModify", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Added!.
        /// </summary>
        internal static string InfoAdded {
            get {
                return ResourceManager.GetString("InfoAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If you wish to perform something check the following commands:
        ///- &apos;u&apos; is for users.
        ///- &apos;b&apos; is for books..
        /// </summary>
        internal static string InfoCommandsAddText {
            get {
                return ResourceManager.GetString("InfoCommandsAddText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If you wish to perform something check the following commands:
        ///- &apos;a&apos; is for adding.
        ///- &apos;r&apos; is for read.
        ///- &apos;m&apos; is for modifying something.
        ///- &apos;b&apos; is for borrowing books.
        ///- &apos;q&apos; is for quit from the program.
        ///- &apos;esc&apos; is for going up one menu level..
        /// </summary>
        internal static string InfoCommandsText {
            get {
                return ResourceManager.GetString("InfoCommandsText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This feature is still under development!
        ///.
        /// </summary>
        internal static string InfoUnderDevelopement {
            get {
                return ResourceManager.GetString("InfoUnderDevelopement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What do you want? Return a book or borrow a book?
        ///- &apos;b&apos; when borrow a book.
        ///- &apos;r&apos; when return a book..
        /// </summary>
        internal static string InfoWantToReturnOrBorrow {
            get {
                return ResourceManager.GetString("InfoWantToReturnOrBorrow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  !!! __Incorrect option, please select from below.__ !!!
        ///.
        /// </summary>
        internal static string InfoWrongInput {
            get {
                return ResourceManager.GetString("InfoWrongInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect value, please enter in some number: .
        /// </summary>
        internal static string InfoWrongInputValue {
            get {
                return ResourceManager.GetString("InfoWrongInputValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose a language for the test:
        ///- &apos;h&apos; is for hungarian.
        ///- &apos;e&apos; is for english.
        ///- &apos;j&apos; is for japanese..
        /// </summary>
        internal static string LanguageSwitch {
            get {
                return ResourceManager.GetString("LanguageSwitch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to , Age: {2}.
        /// </summary>
        internal static string PropertyAge {
            get {
                return ResourceManager.GetString("PropertyAge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to , Author: {2}.
        /// </summary>
        internal static string PropertyAuthor {
            get {
                return ResourceManager.GetString("PropertyAuthor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///The book is borrowed: {0}.
        /// </summary>
        internal static string PropertyBorrowed {
            get {
                return ResourceManager.GetString("PropertyBorrowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to , Email: {3}.
        /// </summary>
        internal static string PropertyEmail {
            get {
                return ResourceManager.GetString("PropertyEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id: {0}.
        /// </summary>
        internal static string PropertyID {
            get {
                return ResourceManager.GetString("PropertyID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Premium user: {0}.
        /// </summary>
        internal static string PropertyPremium {
            get {
                return ResourceManager.GetString("PropertyPremium", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The book is returned: {0}.
        /// </summary>
        internal static string PropertyReturned {
            get {
                return ResourceManager.GetString("PropertyReturned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to , Title: {1}.
        /// </summary>
        internal static string PropertyTitle {
            get {
                return ResourceManager.GetString("PropertyTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to , Name: {1}.
        /// </summary>
        internal static string PropertyUserName {
            get {
                return ResourceManager.GetString("PropertyUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Your Age: .
        /// </summary>
        internal static string UserAge {
            get {
                return ResourceManager.GetString("UserAge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your email: .
        /// </summary>
        internal static string UserEmail {
            get {
                return ResourceManager.GetString("UserEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your name: .
        /// </summary>
        internal static string UserName {
            get {
                return ResourceManager.GetString("UserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of the users logged in to the library is: {0}.
        /// </summary>
        internal static string UserNumberText {
            get {
                return ResourceManager.GetString("UserNumberText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Joshua&apos;s Library Manager.
        /// </summary>
        internal static string WelcomeText {
            get {
                return ResourceManager.GetString("WelcomeText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What do you want to add? 
        ///.
        /// </summary>
        internal static string WhatToAdd {
            get {
                return ResourceManager.GetString("WhatToAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to What do you want to read?
        ///.
        /// </summary>
        internal static string WhatToRead {
            get {
                return ResourceManager.GetString("WhatToRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Who is borrowing the book?
        ///Please enter in his/her ID: .
        /// </summary>
        internal static string WhoIsBorrowing {
            get {
                return ResourceManager.GetString("WhoIsBorrowing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Who is returning the book?
        ///Please enter in his/her ID: .
        /// </summary>
        internal static string WhoIsReturning {
            get {
                return ResourceManager.GetString("WhoIsReturning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Choice: .
        /// </summary>
        internal static string YourChoice {
            get {
                return ResourceManager.GetString("YourChoice", resourceCulture);
            }
        }
    }
}
