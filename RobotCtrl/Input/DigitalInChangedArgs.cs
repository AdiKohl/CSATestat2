//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: DigitalInChangedArgs.cs 2018-03-21 13:55:00 mus-hslu $
//    selber gebastelte Klasse muss wahrscheindlich wiede wegg!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// EventArgs-Klasse um über Änderungen des DigitalenEinganges zu informieren.
    /// </summary>
    public class DigitalInChangedArgs : EventArgs
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert die DigitalInChangedArgs-Klasse
        /// </summary>
        /// <param name="data">der aktuelle Zustand des Schalters</param>
        public DigitalInChangedArgs( int data)
        {
            Data = data;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die Daten
        /// </summary>
        public int Data { get; set; }

        #endregion
    }
}