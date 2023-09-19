import {columns, Container} from "./columns"
import {DataTable} from "./data-table"

async function getData(): Promise<Container[] | null> {
    const response = await fetch(`http://localhost:5236/api/v1/DockerContainer?all=true`, {
        cache: "force-cache",
    });

    if (!response.ok) {
        throw new Error(`Request failed with status code ${response.status}`);
    }

    return response.json();
}

export default async function ContainerDataTableComponent() {
    const data = await getData();

    return <div>
        {
            data
                ? <DataTable columns={columns} data={data}/>
                : <div>Loading...</div>
        }

    </div>
}