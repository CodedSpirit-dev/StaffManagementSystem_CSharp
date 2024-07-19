import { Button } from "@tremor/react"

export const SucessfullModal = () => {
    return (
        <div className=" bg-blue-100 border border-blue-400 text-blue-700 px-4 py-3 rounded relative" role="alert">
            <strong className="font-bold">Éxito!</strong>
            <span className="block sm:inline"> Los datos se han guardado correctamente.</span>
            <Button className="absolute top-0 bottom-0 right-0 px-4 py-3">
                <span className="absolute inset-0 h-full w-full" aria-hidden="true">Cerrar</span>
            </Button>
        </div>
    )
}