import { Link } from "react-router-dom";

export const NavBar = () => {
    return (
        <nav className="bg-gray-300 p-2">
            <ul className="flex justify-center space-x-4">
                <li>
                    <Link to="/">Inicio</Link>
                </li>
                <li>
                    <Link to="/lista">Empleados</Link>
                </li>
                <li>
                    <Link to="/crearUsuario">Crear Empleado</Link>
                </li>
            </ul>
        </nav>
    );
}