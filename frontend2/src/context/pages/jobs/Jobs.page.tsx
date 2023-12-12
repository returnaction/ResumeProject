import React from "react";
import "./jobs.scss";
import httpModule from '../../../helper/http.module'
import { useState, useEffect } from 'react';
import { ICompany, IJob } from '../../../types/global.typing';
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Add } from "@mui/icons-material";
import CompaniesGrid from "../../../companies/Companies.Grid.component";
import JobsGrid from "../../../jobs/JobsGrid.component";

const Jobs = () => {
  const [jobs, setJobs] = useState<IJob[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const redirect = useNavigate();

  useEffect(() => {
    setLoading(true);
    httpModule
      .get<IJob[]>("/Job/Get")
      .then(response => {
        setJobs(response.data);
        setLoading(false);
      })
      .catch((error) => {
        alert("Error")
        console.log(error)
        setLoading(false);
      }
      );
  }, []);

  console.log(jobs)

  return (
    <div className="content companies">
      <div className="heading">
        <h2>Jobs</h2>
        <Button variant="outlined" onClick={() => redirect("/jobs/add")}>
          <Add />
        </Button>
      </div>
      {
        jobs.length === 0 ? <h1>No Jobs</h1> : <JobsGrid data={jobs} />
      }
    </div>

  );
};

export default Jobs;

//2:42:43
