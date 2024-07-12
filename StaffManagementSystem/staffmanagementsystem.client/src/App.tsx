import { useEffect, useState } from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import EmployeeList from './pages/EmployeeList';
import Home from './pages/Home';

function App() {
        return (
            <>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/lista" element={<EmployeeList />} />
                </Routes>
            </>
        );
    }
export default App;