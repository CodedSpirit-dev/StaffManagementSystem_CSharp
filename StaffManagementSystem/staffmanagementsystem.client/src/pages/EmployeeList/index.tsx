import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

interface ContactInfo {
    phoneNumber: string;
    email: string;
}

interface EmploymentDetails{
    hireDate: Date;
    department: string;
    isActive: boolean;
}

interface EmployeeData {
    socialSecurityNumber: number;
    firstName: string;
    lastName: string;
    department: string;
    contactInfo: ContactInfo;
    employmentDetails: EmploymentDetails;
}

function EmployeeList() {
    const [employees, setEmployees] = useState<EmployeeData[]>([]);

    useEffect(() => {
        FetchAllEmployees();
    }, []);

    const contents = employees.length === 0
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Identificador</th>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Numero de telefono</th>
                    <th>Departamento</th>
                    <th>Activo</th>
                </tr>
            </thead>
            <tbody>
                {employees.map(employee =>
                    <tr key={employee.socialSecurityNumber}>
                        <td>{employee.socialSecurityNumber}</td>
                        <td>{employee.firstName}</td>
                        <td>{employee.lastName}</td>
                        <td>{employee.contactInfo.phoneNumber}</td>
                        <td>{employee.employmentDetails.department}</td>
                        <td>{employee.employmentDetails.isActive ? "Si" : "No"}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Employee List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
            <Link to="/">HOME</Link>
        </div>
    );

    async function FetchAllEmployees() {
        const response = await fetch('api/Employees');
        const data: EmployeeData[] = await response.json();
        setEmployees(data);
    }
}

export default EmployeeList;
