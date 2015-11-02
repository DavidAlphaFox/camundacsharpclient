﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamundaCSharpClient.Model;
using CamundaCSharpClient.Helper;
using RestSharp;
using Newtonsoft.Json;
using CamundaCSharpClient.Model.processDefinition;

namespace CamundaCSharpClient.Query
{
    public class ProcessDefinitionQuery : queryBase
    {
        protected string id { get; set; }

        protected string name { get; set; }

        protected string nameLike { get; set; }

        protected string deploymentId { get; set; }

        protected string key { get; set; }

        protected string keyLike { get; set; }

        protected string category { get; set; }

        protected string categoryLike { get; set; }

        protected int? version { get; set; }

        protected string latestVersion { get; set; }

        protected string resourceName { get; set; }

        protected string resourceNameLike { get; set; }

        protected string startableBy { get; set; }

        protected string active { get; set; }

        protected string suspended { get; set; }

        protected string incidentId { get; set; }

        protected string incidentType { get; set; }

        protected string incidentMessage { get; set; }

        protected string incidentMessageLike { get; set; }

        protected int? firstResult { get; set; }

        protected int? maxResults { get; set; }

        protected string sortBy { get; set; }

        protected string sortOrder { get; set; }
        protected string caseInstanceId { get; set; }
        protected string businessKey { get; set; }
        EnsureHelper ensure = null;

        public ProcessDefinitionQuery Id(string id)
        {
            this.id = id;
            return this;
        }
        public ProcessDefinitionQuery Name(string name)
        {
            this.name = name;
            return this;
        }
        public ProcessDefinitionQuery BusinessKey(string businessKey)
        {
            this.businessKey = businessKey;
            return this;
        }
        public ProcessDefinitionQuery CaseInstanceId(string caseInstanceId)
        {
            this.caseInstanceId = caseInstanceId;
            return this;
        }
        public ProcessDefinitionQuery NameLike(string nameLike)
        {
            this.nameLike = nameLike;
            return this;
        }
        public ProcessDefinitionQuery DeploymentId(string deploymentId)
        {
            this.deploymentId = deploymentId;
            return this;
        }
        public ProcessDefinitionQuery Key(string key)
        {
            this.key = key;
            return this;
        }
        public ProcessDefinitionQuery KeyLike(string keyLike)
        {
            this.keyLike = keyLike ;
            return this;
        }
        public ProcessDefinitionQuery Category(string category)
        {
            this.category = category;
            return this;
        }
        public ProcessDefinitionQuery CategoryLike(string categoryLike)
        {
            this.categoryLike = categoryLike;
            return this;
        }
        public ProcessDefinitionQuery Version(int version)
        {
            this.version = version;
            return this;
        }
        public ProcessDefinitionQuery LatestVersion(bool latestVersion)
        {
            this.latestVersion = latestVersion.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery ResourceName(string resourceName)
        {
            this.resourceName = resourceName;
            return this;
        }
        public ProcessDefinitionQuery ResourceNameLike(string resourceNameLike)
        {
            this.resourceNameLike = resourceNameLike;
            return this;
        }
        public ProcessDefinitionQuery StartableBy(string startableBy)
        {
            this.startableBy = startableBy;
            return this;
        }
        public ProcessDefinitionQuery Active(bool active)
        {
            this.active = active.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery Suspended(bool suspended)
        {
            this.suspended = suspended.ToString().ToLower();
            return this;
        }
        public ProcessDefinitionQuery IncidentId(string incidentId)
        {
            this.incidentId = incidentId;
            return this;
        }
        public ProcessDefinitionQuery IncidentType(string incidentType)
        {
            this.incidentType = incidentType;
            return this;
        }
        public ProcessDefinitionQuery IncidentMessage(string incidentMessage)
        {
            this.incidentMessage = incidentMessage;
            return this;
        }
        public ProcessDefinitionQuery IncidentMessageLike(string incidentMessageLike)
        {
            this.incidentMessageLike = incidentMessageLike;
            return this;
        }
        public ProcessDefinitionQuery FirstResult(int firstResult)
        {
            this.firstResult = firstResult;
            return this;
        }
        public ProcessDefinitionQuery MaxResults(int maxResults)
        {
            this.maxResults = maxResults;
            return this;
        }
        public ProcessDefinitionQuery SortByNSortOrder(string sortBy, string sortOrder)
        {
            this.sortBy = sortBy;
            this.sortOrder = sortOrder;
            return this;
        }

        public ProcessDefinitionQuery(camundaRestClient client) :base(client)
        {
            this.ensure = new EnsureHelper();
        }
        /// <summary> Query for process definitions that fulfill given parameters.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pd1 = camundaCl.ProcessDefinition().Suspended(false).list();
        ///</code>
        ///</example>
        public List<processDefinition> list()
        {
            var request = new RestRequest();
            request.Resource = "/process-definition?" + new queryHelper().buildQuery<ProcessDefinitionQuery>(this);
            return list<processDefinition>(request);
        }
        /// <summary> Retrieves a single process definition according to the ProcessDefinition interface in the engine.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pd7 = camundaCl.ProcessDefinition().Key("invoice").singleResult();
        ///</code>
        ///</example>
        public processDefinition singleResult()
        {
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/" + this.id;
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key ;
            }
            return singleResult<processDefinition>(request);
        }
        /// <summary> Request the number of process definitions that fulfill the query criteria
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pd2 = camundaCl.ProcessDefinition().Suspended(false).count();
        ///</code>
        ///</example>
        public Count count()
        {
            var request = new RestRequest();
            request.Resource = "/process-definition/count?" + new queryHelper().buildQuery<ProcessDefinitionQuery>(this);
            return count(request);
        }
        /// <summary> Retrieves the BPMN 2.0 XML of this process definition.
        /// </summary>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pd3 = camundaCl.ProcessDefinition().Key("invoice").Xml();
        /// var pd4 = camundaCl.ProcessDefinition().Id("invoice:1:54302a7a-7736-11e5-bc04-40a8f0a54b22").Xml();
        ///</code>
        ///</example>
        public processDefinitionXML Xml()
        {
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/"+this.id+"/xml";
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key + "/xml";
            }
            return client.Execute<processDefinitionXML>(request);
        }
        /// <summary> Instantiates a given process definition.
        /// </summary>
        /// <param name="variables">A JSON object containing the variables the process is to be initialized with.</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// invoice.CommunicationRootObject d = new invoice.CommunicationRootObject() { comment = new invoice.Comment() { value = "test" }, DeptHead = new invoice.DeptHead() { value = "salajlan" }, approver = new invoice.Approver() { value = "basim"} };
        /// var pd5 = camundaCl.ProcessDefinition().Key("invoice").BusinessKey("hi").start<invoice.CommunicationRootObject>(d);
        ///</code>
        ///</example>
        public processInstance start<T>(T variables)
        {
            this.ensure.ensureNotNull("processDefinitionVariables", variables);
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/" + this.id + "/start";
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key + "/start";
            }

            request.Method = Method.POST;
            object obj = new { variables, this.businessKey, this.caseInstanceId };
            string output = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            return client.Execute<processInstance>(request);
        }
        /// <summary> Activate or suspend a given process definition
        /// </summary>
        /// <param name="data"> processDefinitionSuspend object</param>
        /// <example> 
        /// <code>
        /// var camundaCl = new camundaRestClient("http://localhost:8080/engine-rest");
        /// var pr = new processDefinitionSuspend(){ suspended = false, includeProcessInstances = false, executionDate = DateTime.Now };
        /// var pd6 = camundaCl.ProcessDefinition().Key("invoice").Suspend(pr);
        ///</code>
        ///</example>
        public noContentStatus Suspend(processDefinitionSuspend data)
        {
            var request = new RestRequest();
            if (this.id != null) request.Resource = "/process-definition/" + this.id + "/suspended";
            else
            {
                this.ensure.ensureNotNull("processDefiniftionKey", this.key);
                request.Resource = "/process-definition/key/" + this.key + "/suspended";
            }
            request.Method = Method.PUT;
            string output = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var resp = client.Execute(request);
            return resp.StatusCode == System.Net.HttpStatusCode.NoContent ? noContentStatus.Success : noContentStatus.Failed;
        }
    }
}
