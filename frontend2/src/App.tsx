import { useContext, lazy, Suspense } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./context/navbar/Navbar.component";
import { Routes, Route } from "react-router-dom";
import Home from "./context/pages/home/Home.page";
import Company from "./context/pages/companies/Company.page";
import Job from "./context/pages/jobs/Job.page";
import Candidate from "./context/pages/candidates/Candidate.page";


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
          </Route>
          <Route path="/jobs" element={<Job />} />
          <Route path="/candidates" element={<Candidate />} />
        </Routes>
      </div>
    </div>

  )
}

export default App