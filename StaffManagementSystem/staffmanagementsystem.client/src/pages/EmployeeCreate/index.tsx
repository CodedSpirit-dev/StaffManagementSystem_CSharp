import React from "react";
import { FormProvider, useForm } from "react-hook-form";
import { IEmployeeData } from "../../utils/interfaces";
import { optionsDepartment, optionsGender, optionsMaritalStatus } from "../../utils/Dictionaries";
import axios from "axios";

export const EmployeeCreate: React.FC = () => {
    const methods = useForm<IEmployeeData>();
    const { register, handleSubmit, formState: { errors } } = methods;

    const onSubmit = (data: IEmployeeData) => {
        const formattedData = {
            ...data,
            socialSecurityNumber: data.socialSecurityNumber,
            rfc: data.rfc,
            curp: data.curp,
            firstName: data.firstName,
            middleName: data.middleName,
            lastName: data.lastName,
            secondLastname: data.secondLastname,
            birthDate: new Date(data.birthDate as unknown as string).toISOString().split('T')[0],
            bloodType: data.bloodType,
            maritalStatus: data.maritalStatus,
            children: data.children,
            studyGrade: data.studyGrade,
            contactInfo: {
                email: data.contactInfo.email,
                phoneNumber: data.contactInfo.phoneNumber
            },
            address: {
                addressLine: data.address.addressLine,
                postalCode: data.address.postalCode,
                neighborhood: data.address.neighborhood,
                city: data.address.city,
                state: data.address.state
            },
            employmentDetails: {
                ...data.employmentDetails,
                hiringDate: new Date(data.employmentDetails.hiringDate).toISOString(),
                resignationDate: data.employmentDetails.resignationDate ? new Date(data.employmentDetails.resignationDate).toISOString() : null,
                department: data.employmentDetails.department,
                position: data.employmentDetails.position,
                bossName: data.employmentDetails.bossName,
                shift: data.employmentDetails.shift,
                hiredBy: data.employmentDetails.hiredBy,
                isActive: true,
                isFileComplete: JSON.parse(String(data.employmentDetails.isFileComplete)),
                insuranceActive: true,
                notes: data.employmentDetails.notes
            },
            emergencyContact: {
                emergencyContactName: data.emergencyContact.emergencyContactName,
                emergencyPhone: data.emergencyContact.emergencyPhone,
                emergencyRelationship: data.emergencyContact.emergencyRelationship
            }
        };

        axios.post("https://localhost:5173/api/Employees/Create", formattedData)
            .then(response => {
                response.data;

                window.location.href = "/lista";
            })
            .catch(error => {
                console.error(error);
            });
    };

    return (
        <div>
            <h1>Alta de empleados</h1>
            <h2>Aquí puedes dar de alta a nuevos empleados</h2>
            <FormProvider {...methods}>
                <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col items-center">
                    <div>
                        <div>
                            <h2>Datos Personales</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="firstName">Nombre</label>
                                    <input
                                        type="text"
                                        id="firstName"
                                        className="input_text"
                                        {...register("firstName", { required: "Introduce el nombre" })}
                                    />
                                    {errors.firstName && <p className="error-message">{errors.firstName.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="middleName">Segundo nombre</label>
                                    <input
                                        type="text"
                                        id="middleName"
                                        className="input_text"
                                        {...register("middleName")}
                                    />
                                </div>
                                <div>
                                    <label htmlFor="lastName">Apellido</label>
                                    <input
                                        type="text"
                                        id="lastName"
                                        className="input_text"
                                        {...register("lastName", { required: "No olvides el apellido" })}
                                    />
                                    {errors.lastName && <p className="error-message">{errors.lastName.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="secondLastname">Segundo apellido</label>
                                    <input
                                        type="text"
                                        id="secondLastname"
                                        className="input_text"
                                        {...register("secondLastname")}
                                    />
                                </div>
                                <div>
                                    <label htmlFor="birthDate">Fecha de nacimiento</label>
                                    <input
                                        type="date"
                                        id="birthDate"
                                        className="input_date"
                                        {...register("birthDate", { required: "La fecha de nacimiento es obligatoria" })}
                                    />
                                    {errors.birthDate && <p className="error-message">{errors.birthDate.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="gender">Sexo</label>
                                    <select
                                        id="gender"
                                        className="input_text"
                                        {...register("gender", { required: "Selecciona el sexo" })}
                                    >
                                        {optionsGender.map((option) => (
                                            <option key={option.value} value={option.value}>
                                                {option.label}
                                            </option>
                                        ))}
                                    </select>
                                    {errors.gender && <p className="error-message">{errors.gender.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="bloodType">Tipo de sangre</label>
                                    <select
                                        id="bloodType"
                                        className="input_text"
                                        {...register("bloodType", { required: "Selecciona el tipo de sangre" })}
                                    >
                                        <option value="A+">A+</option>
                                        <option value="A-">A-</option>
                                        <option value="B+">B+</option>
                                        <option value="B-">B-</option>
                                        <option value="AB+">AB+</option>
                                        <option value="AB-">AB-</option>
                                        <option value="O+">O+</option>
                                        <option value="O-">O-</option>
                                        <option value="Desconocido">Desconocido</option>
                                    </select>
                                    {errors.bloodType && <p className="error-message">{errors.bloodType.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="maritalStatus">Estado civil</label>
                                    <select
                                        id="maritalStatus"
                                        className="input_text"
                                        {...register("maritalStatus", { required: "El estado civil es requerido" })}
                                    >
                                        {optionsMaritalStatus.map((option) => (
                                            <option key={option.value} value={option.value}>
                                                {option.label}
                                            </option>
                                        ))}
                                    </select>
                                    {errors.maritalStatus && <p className="error-message">{errors.maritalStatus.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="children">Número de hijos</label>
                                    <input
                                        type="number"
                                        id="children"
                                        className="input_text"
                                        min={0}
                                        max={20}
                                        defaultValue={0}
                                        {...register("children", { required: "El número de hijos no debe estar vacío", min: { value: 0, message: "El número mínimo es 0" }, max: { value: 20, message: "El número máximo es 20" } })}
                                    />
                                    {errors.children && <p className="error-message">{errors.children.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="studyGrade">Ultimo grado de estudios</label>
                                    <select
                                        id="studyGrade"
                                        className="input_text"
                                        {...register("studyGrade", { required: "El ultimo grado de estudios es requerido" })}
                                    >
                                        <option value="primary">Primaria</option>
                                        <option value="secondary">Secundaria</option>
                                        <option value="highSchool">Bachillerato</option>
                                        <option value="university">Licenciatura</option>
                                        <option value="Masters">Maestría</option>
                                        <option value="Doctorate">Doctorado</option>
                                    </select>
                                    {errors.studyGrade && <p className="error-message">{errors.studyGrade.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="socialSecurityNumber">Número de seguro social</label>
                                    <input
                                        type="text"
                                        id="socialSecurityNumber"
                                        className="input_text"
                                        {...register("socialSecurityNumber", { required: "Por favor, introduce un número de seguro social." })}
                                    />
                                    {errors.socialSecurityNumber && <p className="error-message">{errors.socialSecurityNumber.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="rfc">RFC</label>
                                    <input
                                        type="text"
                                        id="rfc"
                                        className="input_text"
                                        {...register("rfc", { required: "Por favor, introduce un RFC." })}
                                    />
                                    {errors.rfc && <p className="error-message">{errors.rfc.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="curp">CURP</label>
                                    <input
                                        type="text"
                                        id="curp"
                                        className="input_text"
                                        {...register("curp", { required: "Por favor, introduce un CURP." })}
                                    />
                                    {errors.curp && <p className="error-message">{errors.curp.message}</p>}
                                </div>
                            </div>
                            <h2>Datos de contacto</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="contactInfo.email">Email</label>
                                    <input
                                        type="email"
                                        id="contactInfo.email"
                                        className="input_text"
                                        {...register("contactInfo.email", { required: "Por favor, introduce un email." })}
                                    />
                                    {errors.contactInfo?.email && <p className="error-message">{errors.contactInfo.email.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="contactInfo.phoneNumber">Número de teléfono</label>
                                    <input
                                        type="tel"
                                        id="contactInfo.phoneNumber"
                                        className="input_text"
                                        {...register("contactInfo.phoneNumber", { required: "Por favor, introduce un número de teléfono." })}
                                    />
                                    {errors.contactInfo?.phoneNumber && <p className="error-message">{errors.contactInfo.phoneNumber.message}</p>}
                                </div>
                            </div>
                            <h2>Dirección</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="address.addressLine">Dirección</label>
                                    <input
                                        type="text"
                                        id="address.addressLine"
                                        className="input_text"
                                        {...register("address.addressLine", { required: "Por favor, introduce una dirección." })}
                                    />
                                    {errors.address?.addressLine && <p className="error-message">{errors.address.addressLine.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="address.postalCode">Código postal</label>
                                    <input
                                        type="text"
                                        id="address.postalCode"
                                        className="input_text"
                                        {...register("address.postalCode", { required: "Por favor, introduce un código postal." })}
                                    />
                                    {errors.address?.postalCode && <p className="error-message">{errors.address.postalCode.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="address.neighborhood">Colonia</label>
                                    <input
                                        type="text"
                                        id="address.neighborhood"
                                        className="input_text"
                                        {...register("address.neighborhood", { required: "Por favor, introduce una colonia." })}
                                    />
                                    {errors.address?.neighborhood && <p className="error-message">{errors.address.neighborhood.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="address.city">Ciudad</label>
                                    <input
                                        type="text"
                                        id="address.city"
                                        className="input_text"
                                        {...register("address.city", { required: "Por favor, introduce una ciudad." })}
                                    />
                                    {errors.address?.city && <p className="error-message">{errors.address.city.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="address.state">Estado</label>
                                    <input
                                        type="text"
                                        id="address.state"
                                        className="input_text"
                                        {...register("address.state", { required: "Por favor, introduce un estado." })}
                                    />
                                    {errors.address?.state && <p className="error-message">{errors.address.state.message}</p>}
                                </div>
                            </div>
                            <h2>Detalles de empleo</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="employmentDetails.hiringDate">Fecha de contratación</label>
                                    <input
                                        type="date"
                                        id="employmentDetails.hiringDate"
                                        className="input_date"
                                        {...register("employmentDetails.hiringDate", { required: "La fecha de contratación es requerida" })}
                                    />
                                    {errors.employmentDetails?.hiringDate && <p className="error-message">{errors.employmentDetails.hiringDate.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.department">Departamento</label>
                                    <select id="employmentDetails.department" className="input_text" {...register("employmentDetails.department", { required: "El departamento es requerido" })}>
                                        <option value="">Seleccionar</option>
                                        {optionsDepartment.map((option) => (
                                        (<option key={option.value} value={option.value}>{option.label}</option>
                                        )
                                        ))}
                                    </select>
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.position">Puesto</label>
                                    <input
                                        type="text"
                                        id="employmentDetails.position"
                                        className="input_text"
                                        {...register("employmentDetails.position", { required: "El puesto es requerido" })}
                                    />
                                    {errors.employmentDetails?.position && <p className="error-message">{errors.employmentDetails.position.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.bossName">Nombre del jefe</label>
                                    <input
                                        type="text"
                                        id="employmentDetails.bossName"
                                        className="input_text"
                                        {...register("employmentDetails.bossName")}
                                    />
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.shift">Turno</label>
                                    <input
                                        type="text"
                                        id="employmentDetails.shift"
                                        className="input_text"
                                        {...register("employmentDetails.shift", { required: "El turno es requerido" })}
                                    />
                                    {errors.employmentDetails?.shift && <p className="error-message">{errors.employmentDetails.shift.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.hiredBy">Contratado por</label>
                                    <input
                                        type="text"
                                        id="employmentDetails.hiredBy"
                                        className="input_text"
                                        {...register("employmentDetails.hiredBy", { required: "El campo 'Contratado por' es requerido" })}
                                    />
                                    {errors.employmentDetails?.hiredBy && <p className="error-message">{errors.employmentDetails.hiredBy.message}</p>}
                                </div>
                                <div>
<label htmlFor="employmentDetails.isFileComplete">¿Archivo completo?</label>
                                    <select
                                        id="employmentDetails.isFileComplete"
                                        className="input_text"
                                        {...register("employmentDetails.isFileComplete", { required: "Por favor, selecciona si el archivo está completo." })}
                                    >
                                        <option value="true">Sí</option>
                                        <option value="false">No</option>
                                    </select>
                                    {errors.employmentDetails?.isFileComplete && <p className="error-message">{errors.employmentDetails.isFileComplete.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="employmentDetails.notes">Notas</label>
                                    <textarea
                                        id="employmentDetails.notes"
                                        className="input_text"
                                        {...register("employmentDetails.notes")}
                                    />
                                </div>
                            </div>
                            <h2>Contacto de emergencia</h2>
                            <div className="grid grid-cols-2 gap-4">
                                <div>
                                    <label htmlFor="emergencyContact.emergencyContactName">Nombre</label>
                                    <input
                                        type="text"
                                        id="emergencyContact.emergencyContactName"
                                        className="input_text"
                                        {...register("emergencyContact.emergencyContactName", { required: "Por favor, introduce un nombre para el contacto de emergencia." })}
                                    />
                                    {errors.emergencyContact?.emergencyContactName && <p className="error-message">{errors.emergencyContact.emergencyContactName.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="emergencyContact.emergencyPhone">Teléfono</label>
                                    <input
                                        type="tel"
                                        id="emergencyContact.emergencyPhone"
                                        className="input_text"
                                        {...register("emergencyContact.emergencyPhone", { required: "Por favor, introduce un teléfono para el contacto de emergencia." })}
                                    />
                                    {errors.emergencyContact?.emergencyPhone && <p className="error-message">{errors.emergencyContact.emergencyPhone.message}</p>}
                                </div>
                                <div>
                                    <label htmlFor="emergencyContact.emergencyRelationship">Relación</label>
                                    <input
                                        type="text"
                                        id="emergencyContact.emergencyRelationship"
                                        className="input_text"
                                        {...register("emergencyContact.emergencyRelationship", { required: "Por favor, introduce la relación del contacto de emergencia." })}
                                    />
                                    {errors.emergencyContact?.emergencyRelationship && <p className="error-message">{errors.emergencyContact.emergencyRelationship.message}</p>}
                                </div>
                            </div>
                        </div>
                        <button type="submit" className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mt-4">Enviar</button>
                    </div>
                </form>
            </FormProvider>
        </div>
    );
};
