// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections;
using System.Globalization;
using Xunit;

public class DirectoryInfo_set_Attributes
{
    public static String s_strActiveBugNums = "14952";
    public static String s_strClassMethod = "Directory.CreationTime";
    public static String s_strTFName = "set_Attributes.cs";
    public static String s_strTFPath = Directory.GetCurrentDirectory();

    [Fact]
    public static void runTest()
    {
        int iCountErrors = 0;
        int iCountTestcases = 0;
        String strLoc = "Loc_000oo";
        String strValue = String.Empty;

        string dirName = Path.Combine(TestInfo.CurrentDirectory, Path.GetRandomFileName());
        Directory.CreateDirectory(dirName);

        try
        {
            DirectoryInfo dir = null;
            FileAttributes diratt;

            new DirectoryInfo(dirName).Attributes = new FileAttributes();

            // [] Invalid value

            strLoc = "Loc_09t77";

            dir = new DirectoryInfo(dirName);
            iCountTestcases++;
            try
            {
                dir.Attributes = ~FileAttributes.ReadOnly;
                iCountErrors++;
                printerr("Error_78t59! Expected exception not thrown");
            }
            catch (ArgumentException)
            {
            }
            catch (Exception exc)
            {
                iCountErrors++;
                printerr("Error_97678! Incorrect exception thrown, exc==" + exc.ToString());
            }

            // [] Set the ReadOnly attribute

            strLoc = "Loc_039ux";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.ReadOnly;
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((diratt & (FileAttributes.ReadOnly | FileAttributes.Directory)) != (FileAttributes.ReadOnly | FileAttributes.Directory))
            {
                iCountErrors++;
                printerr("Error_2989d! Incorrect directory attribute set");
            }
            dir.Attributes = new FileAttributes();

            // [] Set hidden only

            strLoc = "Loc_209cu";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.Hidden;
            diratt = dir.Attributes;
            iCountTestcases++;
#if TEST_WINRT  // WinRT doesn't support hidden
            if((diratt & (FileAttributes.Hidden|FileAttributes.Directory)) != (FileAttributes.Directory)) {
#else
            if ((diratt & (FileAttributes.Hidden | FileAttributes.Directory)) != (FileAttributes.Hidden | FileAttributes.Directory))
            {
#endif
                iCountErrors++;
                printerr("Error_3091h! Incorrect direcotory attribute set");
            }
            dir.Attributes = new FileAttributes();

            // [] Set hidden and readonly

            strLoc = "Loc_390uv";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;
            diratt = dir.Attributes;
            iCountTestcases++;
#if !TEST_WINRT  // WinRT doesn't support hidden
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((int)(diratt & FileAttributes.Hidden) == 0)
            {
                iCountErrors++;
                printerr("Error_20x97! Hidden attribute not set");
            }
#endif
            iCountTestcases++;
            if ((int)(diratt & FileAttributes.ReadOnly) == 0)
            {
                iCountErrors++;
                printerr("Error_1990c! ReadOnly attribute not set");
            }
            dir.Attributes = new FileAttributes();

            // [] Set system

            strLoc = "Loc_8gy0b";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.System;
            diratt = dir.Attributes;
            iCountTestcases++;
#if TEST_WINRT  // WinRT doesn't support system
            if((diratt & (FileAttributes.System|FileAttributes.Directory)) != (FileAttributes.Directory)) {
#else
            if ((diratt & (FileAttributes.System | FileAttributes.Directory)) != (FileAttributes.System | FileAttributes.Directory))
            {
#endif
                iCountErrors++;
                printerr("Error_7t87y! System attribute not set");
            }
            dir.Attributes = new FileAttributes();

            // [] set archive

            strLoc = "Loc_29d88";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.Archive;
            diratt = dir.Attributes;
            iCountTestcases++;
#if TEST_WINRT  // WinRT doesn't support archive
            if((diratt & (FileAttributes.Archive|FileAttributes.Directory)) != (FileAttributes.Directory)) {
#else
            if ((diratt & (FileAttributes.Archive | FileAttributes.Directory)) != (FileAttributes.Archive | FileAttributes.Directory))
            {
#endif
                iCountErrors++;
                printerr("Error_f487b! System attribute not set");
            }
            dir.Attributes = new FileAttributes();

            // [] Encrypted can't be set on directory

            strLoc = "Loc_t78yg";

            /*			dir = new DirectoryInfo(".");
                        dir.Attributes = FileAttributes.Encrypted;
                        diratt = dir.Attributes;
                        iCountTestcases++;
                        if(diratt != FileAttributes.Directory) {
                            iCountErrors++;
                            printerr( "Error_09828! System attribute not set");
                        } 
                        dir.Attributes = new FileAttributes();                   */

            // [] Normal can't be set on directory

            strLoc = "Loc_90v77";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.Normal;
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((diratt & FileAttributes.Directory) == 0)
            {
                iCountErrors++;
                printerr("Error_2t09b! System attribute not set");
            }
            dir.Attributes = new FileAttributes();


            /*       		// [] Temporary can't be set on directory

                       strLoc = "Loc_99g94";

                       dir = new DirectoryInfo(".");
                       iCountTestcases++;
                       try {
                           dir.Attributes = FileAttributes.Temporary;
                           iCountErrors++;
                           printerr( "Error_247tb! Expected exception not thrown");
                       } catch (ArgumentException aexc) {
                       } catch (Exception exc) {
                           iCountErrors++;
                           printerr( "Error_758bh! Incorrect exception thrown, exc=="+exc.ToString());
                       }
                       dir.Attributes = new FileAttributes();   */


            // [] Sparsefile can't be set on directory

            strLoc = "Loc_8gy0b";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.SparseFile;
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((diratt & (FileAttributes.Directory)) == 0)
            {
                iCountErrors++;
                printerr("Error_1300g! SparseFile attribute not set");
            }
            dir.Attributes = new FileAttributes();


            // [] ReparsePoint can't be set on directory


            strLoc = "Loc_9180c";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.ReparsePoint;
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((diratt & (FileAttributes.Directory)) == 0)
            {
                iCountErrors++;
                printerr("Error_0199c! ReparsePoint attribute not set");
            }
            dir.Attributes = new FileAttributes();

            // [] Compressed can't be set on directory


            strLoc = "Loc_0200d";

            dir = new DirectoryInfo(dirName);
            dir.Attributes = FileAttributes.Compressed;
            diratt = dir.Attributes;
            iCountTestcases++;
            if ((diratt & (FileAttributes.Directory)) == 0)
            {
                iCountErrors++;
                printerr("Error_9010c! Compressed attribute not set");
            }
            dir.Attributes = new FileAttributes();

            // [] Offline
            iCountTestcases++;
            /* Does not work on FAT filesystems
                        strLoc = "Loc_109tg";

                        dir = new DirectoryInfo(".");
                        dir.Attributes = FileAttributes.Offline;
                        diratt = dir.Attributes;
                        iCountTestcases++;
                        if(diratt != (FileAttributes.Offline|FileAttributes.Directory)) {
                            iCountErrors++;
                            printerr( "Error_010vy! Offline attribute not set");
                        } 
                        dir.Attributes = new FileAttributes();


                        // [] NotContectIndexed

                        strLoc = "Loc_t0698";

                        dir = new DirectoryInfo(".");
                        dir.Attributes = FileAttributes.NotContentIndexed;
                        diratt = dir.Attributes;
                        iCountTestcases++;
                        if(diratt != (FileAttributes.NotContentIndexed|FileAttributes.Directory)) {
                            iCountErrors++;
                            printerr( "Error_23047! NotContentIndexed attribute not set");
                        } 
                        dir.Attributes = new FileAttributes();
            */
        }
        catch (Exception exc_general)
        {
            ++iCountErrors;
            Console.WriteLine("Error Err_8888yyy!  strLoc==" + strLoc + ", exc_general==" + exc_general.ToString());
        }
        ////  Finish Diagnostics
        if (iCountErrors != 0)
        {
            Console.WriteLine("FAiL! " + s_strTFName + " ,iCountErrors==" + iCountErrors.ToString());
        }

        Assert.Equal(0, iCountErrors);
    }

    public static void printerr(String err, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
    {
        Console.WriteLine("ERROR: ({0}, {1}, {2}) {3}", memberName, filePath, lineNumber, err);
    }
}

