﻿namespace CardonerSistemas.Reports.Net.Model;

public partial class Report
{
    public enum PageSizes
    {
        //
        // Summary:
        //     The width or height of the page are set manually and override the PageSize property.
        Undefined = 0,
        //
        // Summary:
        //     Identifies a paper sheet size of 841 mm by 1189 mm or 33.11 inches by 46.81 inches.
        A0 = 1,
        //
        // Summary:
        //     Identifies a paper sheet size of 594 mm by 841 mm or 23.39 inches by 33.1 inches.
        A1 = 2,
        //
        // Summary:
        //     Identifies a paper sheet size of 420 mm by 594 mm or 16.54 inches by 23.29 inches.
        A2 = 3,
        //
        // Summary:
        //     Identifies a paper sheet size of 297 mm by 420 mm or 11.69 inches by 16.54 inches.
        A3 = 4,
        //
        // Summary:
        //     Identifies a paper sheet size of 210 mm by 297 mm or 8.27 inches by 11.69 inches.
        A4 = 5,
        //
        // Summary:
        //     Identifies a paper sheet size of 148 mm by 210 mm or 5.83 inches by 8.27 inches.
        A5 = 6,
        //
        // Summary:
        //     Identifies a paper sheet size of 860 mm by 1220 mm.
        RA0 = 7,
        //
        // Summary:
        //     Identifies a paper sheet size of 610 mm by 860 mm.
        RA1 = 8,
        //
        // Summary:
        //     Identifies a paper sheet size of 430 mm by 610 mm.
        RA2 = 9,
        //
        // Summary:
        //     Identifies a paper sheet size of 305 mm by 430 mm.
        RA3 = 10,
        //
        // Summary:
        //     Identifies a paper sheet size of 215 mm by 305 mm.
        RA4 = 11,
        //
        // Summary:
        //     Identifies a paper sheet size of 153 mm by 215 mm.
        RA5 = 12,
        //
        // Summary:
        //     Identifies a paper sheet size of 1000 mm by 1414 mm or 39.37 inches by 55.67
        //     inches.
        B0 = 13,
        //
        // Summary:
        //     Identifies a paper sheet size of 707 mm by 1000 mm or 27.83 inches by 39.37 inches.
        B1 = 14,
        //
        // Summary:
        //     Identifies a paper sheet size of 500 mm by 707 mm or 19.68 inches by 27.83 inches.
        B2 = 15,
        //
        // Summary:
        //     Identifies a paper sheet size of 353 mm by 500 mm or 13.90 inches by 19.68 inches.
        B3 = 16,
        //
        // Summary:
        //     Identifies a paper sheet size of 250 mm by 353 mm or 9.84 inches by 13.90 inches.
        B4 = 17,
        //
        // Summary:
        //     Identifies a paper sheet size of 176 mm by 250 mm or 6.93 inches by 9.84 inches.
        B5 = 18,
        //
        // Summary:
        //     Identifies a paper sheet size of 10 inches by 8 inches or 254 mm by 203 mm.
        Quarto = 100,
        //
        // Summary:
        //     Identifies a paper sheet size of 13 inches by 8 inches or 330 mm by 203 mm.
        Foolscap = 101,
        //
        // Summary:
        //     Identifies a paper sheet size of 10.5 inches by 7.25 inches or 267 mm by 184
        //     mm.
        Executive = 102,
        //
        // Summary:
        //     Identifies a paper sheet size of 10.5 inches by 8 inches or 267 mm by 203 mm.
        GovernmentLetter = 103,
        //
        // Summary:
        //     Identifies a paper sheet size of 11 inches by 8.5 inches or 279 mm by 216 mm.
        Letter = 104,
        //
        // Summary:
        //     Identifies a paper sheet size of 14 inches by 8.5 inches or 356 mm by 216 mm.
        Legal = 105,
        //
        // Summary:
        //     Identifies a paper sheet size of 17 inches by 11 inches or 432 mm by 279 mm.
        Ledger = 106,
        //
        // Summary:
        //     Identifies a paper sheet size of 17 inches by 11 inches or 432 mm by 279 mm.
        Tabloid = 107,
        //
        // Summary:
        //     Identifies a paper sheet size of 19.25 inches by 15.5 inches or 489 mm by 394
        //     mm.
        Post = 108,
        //
        // Summary:
        //     Identifies a paper sheet size of 20 inches by 15 inches or 508 mm by 381 mm.
        Crown = 109,
        //
        // Summary:
        //     Identifies a paper sheet size of 21 inches by 16.5 inches or 533 mm by 419 mm.
        LargePost = 110,
        //
        // Summary:
        //     Identifies a paper sheet size of 22.5 inches by 17.5 inches or 572 mm by 445
        //     mm.
        Demy = 111,
        //
        // Summary:
        //     Identifies a paper sheet size of 23 inches by 18 inches or 584 mm by 457 mm.
        Medium = 112,
        //
        // Summary:
        //     Identifies a paper sheet size of 25 inches by 20 inches or 635 mm by 508 mm.
        Royal = 113,
        //
        // Summary:
        //     Identifies a paper sheet size of 28 inches by 23 inches or 711 mm by 584 mm.
        Elephant = 114,
        //
        // Summary:
        //     Identifies a paper sheet size of 35 inches by 23.5 inches or 889 mm by 597 mm.
        DoubleDemy = 115,
        //
        // Summary:
        //     Identifies a paper sheet size of 45 inches by 35 inches or 1143 by 889 mm.
        QuadDemy = 116,
        //
        // Summary:
        //     Identifies a paper sheet size of 8.5 inches by 5.5 inches or 216 mm by 396 mm.
        STMT = 117,
        //
        // Summary:
        //     Identifies a paper sheet size of 8.5 inches by 13 inches or 216 mm by 330 mm.
        Folio = 120,
        //
        // Summary:
        //     Identifies a paper sheet size of 5.5 inches by 8.5 inches or 396 mm by 216 mm.
        Statement = 121,
        //
        // Summary:
        //     Identifies a paper sheet size of 10 inches by 14 inches.
        Size10x14 = 122
    }
}
