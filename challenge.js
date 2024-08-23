function traverseEnchantedForest(path) {
    const splitString = path.split("/")
    const collectedItems = new Array();
    const manipulatedPath = splitString.map(arr => {
        if (arr.includes("M")) {
            return arr.replace(/M/g, "");
        } else if (arr.includes("C")) {
            const count = (arr.match(/C/g) || []).length;
            for (let i = 0; i < count; i++) {
                collectedItems.push("C");
            }
            return arr;
        } else {
            return arr;
        }
    }).join("/") 
    return [
        manipulatedPath,collectedItems
    ]


}
const path = "TT/RRC/TMCM/CC/MM";
console.log(traverseEnchantedForest(path));