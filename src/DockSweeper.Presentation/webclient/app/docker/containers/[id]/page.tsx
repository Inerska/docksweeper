import {Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle} from "@/components/ui/card";
import {ArrowLeft, ContainerIcon} from "lucide-react";
import Link from "next/link";

export default function Page({params}: { params: { id: string } }) {
    return (
        <div>
            <header className="mb-5 flex flex-col gap-3">
                <Link
                    href={"/"}
                    className="self-start hover:-translate-x-5 transition-transform duration-200 mb-5 ease-in-out hover:text-slate-500"
                >
                    <ArrowLeft/>
                </Link>
                <h1 className="font-semibold text-3xl">Container details</h1>
                <h2 className="text-slate-500">{params.id}</h2>
            </header>

            <Card>
            <CardHeader className="flex flex-row w-full items-center gap-5">
                <ContainerIcon/>
                <CardTitle className="text-2xl">Container Information</CardTitle>
            </CardHeader>
            <CardContent>
                <ul className="flex flex-col gap-2">
                    <li>Id: {params.id}</li>
                    <li>Names: {params.id}</li>
                    <li>Images: {params.id}</li>
                    <li>Command: {params.id}</li>
                    <li>Created: {params.id}</li>
                    <li>State: {params.id}</li>
                </ul>
            </CardContent>
        </Card>
    </div>);
}