import { Route, Routes } from 'react-router-dom';
import EmployeeList from './pages/EmployeeList';
import Home from './pages/Home';
import { NavBar } from './components/NavBar/NavBar';
import EmployeeManagement from './pages/EmployeeCreate';
import { Footer } from './components/Footer/Footer';

function App() {
        return (
            <>
            <NavBar />
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/lista" element={<EmployeeList />} />
                    <Route path="/crearUsuario" element={<EmployeeManagement/>} />
                </Routes>
                <Footer />
            </>
        );
    }
export default App;