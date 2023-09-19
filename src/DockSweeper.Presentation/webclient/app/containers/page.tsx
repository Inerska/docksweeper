"use client";

import {columns} from "./columns"
import {DataTable} from "./data-table"
import {useEffect, useState} from "react";

export default async function ContainerDataTableComponent() {
    const [data, setData] = useState([]);
    const [isLoading, setLoading] = useState(true);
    
    useEffect(() =>{
        fetch(`http://localhost:5236/api/containers?all=true`, {
            cache: "force-cache",
        })
            .then(response => response.json())
            .then(data => {
                setData(data);
                setLoading(false);
            })
    }, [])

    if (isLoading) return <p>Loading...</p>
    if (!data) return <p>No profile data</p>
    
    return <div>
        {
            data
                ? <DataTable columns={columns} data={data}/>
                : <div>Loading...</div>
        }

    </div>
}