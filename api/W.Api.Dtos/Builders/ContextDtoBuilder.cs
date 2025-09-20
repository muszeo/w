//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ContextDtoBuilder.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using W.Api.Settings;
using W.Api.Exceptions;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Dtos.Builders
{

    /// <summary>
    /// ContextDtoBuilder
    /// </summary>
    public static class ContextDtoBuilder
    {
        #region From
        /// <summary>Froms the specified model.</summary>
        /// <param name="dto">The dto.</param>
        /// <param name="model">The model.</param>
        /// <param name="queueFor">The QueueFor (in milliseconds)</param>
        /// <param name="autoObserve">The Auto-Observe Metrics</param>
        /// <returns>
        /// ContextDto
        /// </returns>
        /// <exception cref="W.Api.Exceptions.EntityReferenceNullException"></exception>
        public static ContextDto From (this ContextDto dto, ILocation model, string queueFor, IDictionary<string, (string, string, string)> autoObserve)
        {
            if (model != null) {

                // Internal Event Id
                dto.Id = model.Id;

                // Attributes
                dto.Start = model.Start;
                dto.End = model.End;
                dto.SubjectIdentifier = model.SubjectIdentifier;
                dto.Provider = model.Provider;
                dto.CreatedOn = model.CreatedOn;

                // Queue Depth Period (in milliseconds)
                dto.QueueFor = queueFor;

                // Auto-Observe Metrics
                dto.AutoObserve = new List<AutoObserveDto> ();
                if (autoObserve != null && autoObserve.Keys.Count > 0) {
                    foreach (string _k in autoObserve.Keys) {
                        dto.AutoObserve.Add (
                            new AutoObserveDto () {
                                MetricId = _k,
                                Role = autoObserve [_k].Item1,
                                Args = autoObserve [_k].Item2,
                                Recur = autoObserve [_k].Item3
                            }
                        );
                    }
                }

            } else {
                throw new EntityReferenceNullException ("IdentityContext");
            }

            return dto;
        }
        #endregion
    }
}