export const revalidate = 0;

import {columns, Container} from "./columns"
import {DataTable} from "./data-table"

async function getData(): Promise<Container[]> {
    let data = [];

    try {
        const response = await fetch(`http://api/api/v1/DockerContainer?all=true`);
        data = await response.json();
    } catch (err) {
        console.error('Failed to fetch data:', err);
        return [];
    }
    
    return data;
}

export default async function ContainerDataTableComponent() {
    const data = await getData();

    return <div>
        <DataTable columns={columns} data={data}/>
    </div>
}