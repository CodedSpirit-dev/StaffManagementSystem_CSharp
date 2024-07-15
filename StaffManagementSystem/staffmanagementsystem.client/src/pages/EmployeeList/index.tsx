import { Table, TableBody, TableCell, TableHead, TableHeaderCell, TableRow } from "@tremor/react";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

interface ContactInfo {
    phoneNumber: string;
    email: string;
}

interface EmploymentDetails {
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
        : <div className="mx-auto max-w-2xl">
            <Table className="table-auto border border-slate-300 border-opacity-70 divide-tremor-content-emphasis">
                <TableHead>
                    <TableRow>
                        <TableHeaderCell>Identificador</TableHeaderCell>
                        <TableHeaderCell>Nombre</TableHeaderCell>
                        <TableHeaderCell>Apellido</TableHeaderCell>
                        <TableHeaderCell>Numero de telefono</TableHeaderCell>
                        <TableHeaderCell>Departamento</TableHeaderCell>
                        <TableHeaderCell>Activo</TableHeaderCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {employees.map((employee, index) =>
                        <TableRow key={employee.socialSecurityNumber} className={index % 2 === 0 ? 'row-even' : 'row-odd'}>
                            <TableCell className="text-center">{employee.socialSecurityNumber}</TableCell>
                            <TableCell>{employee.firstName}</TableCell>
                            <TableCell>{employee.lastName}</TableCell>
                            <TableCell className="text-center">{employee.contactInfo.phoneNumber}</TableCell>
                            <TableCell>{employee.employmentDetails.department}</TableCell>
                            <TableCell className="text-center">{employee.employmentDetails.isActive ? "Si" : "No"}</TableCell>
                        </TableRow>
                    )}
                </TableBody>
            </Table>
        </div>;

    return (
        <div>
            <h1 className="text-2xl font-extrabold m-3">Employee List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function FetchAllEmployees() {
        const response = await fetch('api/Employees');
        const data: EmployeeData[] = await response.json();
        setEmployees(data);
    }
}

export default EmployeeList;
