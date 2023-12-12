import { useContext, lazy, Suspense } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./context/navbar/Navbar.component";
import { Routes, Route } from "react-router-dom";
import Home from "./context/pages/home/Home.page";
import Company from "./context/pages/companies/Company.page";
import Job from "./context/pages/jobs/Jobs.page";
import Candidate from "./context/pages/candidates/Candidate.page";
import { Mixins } from "@mui/material";
import AddCompany from "./companies/AddCompany.page";
import Jobs from "./context/pages/jobs/Jobs.page";


const App = () => {
  const { darkMode } = useContext(ThemeContext);

  const appStyles = darkMode ? "app dark" : "app";

  return (
    <div className={appStyles}>
      <Navbar />
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/companies" >
            <Route index element={<Company />} />
            <Route path="add" element={<AddCompany />} />
          </Route>
          <Route path="/jobs" element={<Job />} >
            <Route index element={<Jobs />} />
          </Route>
          <Route path="/candidates" element={<Candidate />} />
        </Routes>
      </div>
    </div>

  )
}

export default App