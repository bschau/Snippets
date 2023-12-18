public static void CorrectStruct(string src, string dest) 
{
	var pdfReader = new PdfReader(src);
	PdfDocument pdfDocument = new PdfDocument(pdfReader, new PdfWriter(dest));
	var rootKids = pdfDocument.GetStructTreeRoot().GetKids();
	if (rootKids.Count > 0)
	{
		var firstKid = (PdfStructElem)rootKids[0];
		firstKid.SetRole(PdfName.P); 
	}
	pdfDocument.Close();
}   
